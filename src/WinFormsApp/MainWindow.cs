// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NMARC.Models;
using NMARC.Serialization;

namespace NMARC
{
    public partial class FrmNativeModeConc : Form
    {
        // Petri Puustinen: Added csvSeparator parameter to control CSV export output separator. Default is comma
        private char csvSeparator = ',';

        public FrmNativeModeConc()
        {
            InitializeComponent();
        }

        private void LoadYamlFile_Click(object sender, EventArgs e)
        {
            if (dlgOpenYaml.ShowDialog() == DialogResult.OK)
            {
                txtYamlInputPath.Text = dlgOpenYaml.FileName;
                txtResultsBox.Text = "";
            }
        }

        private void BtnSetOutputDir_Click(object sender, EventArgs e)
        {
            if (DlgSelectOutputFolder.ShowDialog() == DialogResult.OK)
            {
                TxtOutputPath.Text = DlgSelectOutputFolder.SelectedPath;
                btnConvert.Enabled = true;
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            txtResultsBox.Text += "Started conversion...\n\r\n";

            try
            {
                if (!string.IsNullOrEmpty(txtCsvSeparator.Text))
                {
                    csvSeparator = char.Parse(txtCsvSeparator.Text);
                }

                var report = AlignmentReportParser.ParseAlignmentReport(txtYamlInputPath.Text);
                
                txtResultsBox.Text += "YAML file loaded and parsed.\n\r\n";
                txtResultsBox.Text += $"Found {report.Groups.Count} groups and {report.Users.Count} users.\n\r\n";
                
                if (report.Groups.Count == 0 && report.Users.Count == 0)
                {
                    txtResultsBox.Text += $"No items to export.\n\r\n";
                }
                else
                { 
                    txtResultsBox.Text += $"Exporting to {TxtOutputPath.Text}.\n\r\n";
                    ExportReport(report, csvSeparator);
                    txtResultsBox.Text += "Export complete.\n\r\n";
                }
            }
            catch (Exception exception)
            {
                txtResultsBox.Text += exception;

                txtResultsBox.Text +=
                    "\n\r\n\n\r\nAn error occurred. Please report the messages listed above after removing any sensitive data.\n\r\n";
            }
        }

        /// <summary>
        /// Exports the alignment report to multiple files in a specific folder.
        /// </summary>
        /// <param name="report">AlignmentReport instance containing deserialized data.</param>
        private void ExportReport(AlignmentReport report, char csvSeparator)
        {
            // TODO: Refactoring the code in this method requires some extra work:
            //       * Headers match up with the models. Use reflection, or something newer in C#, to get these automatically.
            //       * Manually parse the YAML, so that we don't have to deal with the dictionaries at the top-level.
            //       * Warn about path not being selected.

            string basePath = DlgSelectOutputFolder.SelectedPath;

            Console.WriteLine("Write...");
            
            WriteGroupsReport(report, basePath, csvSeparator);

            WriteUsersReport(report, basePath, csvSeparator);

            WriteGroupAdminsReport(report, basePath, csvSeparator);

            WriteActiveCommunityGuestsReport(report, basePath, csvSeparator);

            WriteOtherCommunityGuestsReport(report, basePath, csvSeparator);
        }

        // Petri Puustinen: Added csvSeparator parameter to control CSV export output separator
        private static void WriteGroupAdminsReport(AlignmentReport report, string basePath, char csvSeparator)
        {
            var groupAdminOutput = new StringBuilder();
            groupAdminOutput.AppendLine($"GroupID{csvSeparator}CreationRightsState{csvSeparator}Email");

            foreach (var group in report.Groups)
            {
                var admins = group.Administrators;

                if (!(admins is string))
                {
                    Console.WriteLine($@"Group:{group.Administrators}");
                    var convAdmins = (Dictionary<object, object>) admins;

                    foreach (KeyValuePair<object, object> entry in convAdmins)
                    {
                        var key = entry.Key as string;
                        var vals = (List<object>)entry.Value;

                        foreach (var adminEmail in vals)
                        {
                            var email = (string) adminEmail;
                            groupAdminOutput.AppendLine( $"{group.Id}{csvSeparator}{key}{csvSeparator}{email}");
                        }
                    }
                }
                else
                {
                    groupAdminOutput.AppendLine($"{group.Id}{csvSeparator}{csvSeparator}No Admins");
                }
            }

            Utilities.WriteFile($@"{basePath}\groupadmins.csv", groupAdminOutput);
        }

        // Petri Puustinen: Added csvSeparator parameter to control CSV export output separator
        private static void WriteActiveCommunityGuestsReport(AlignmentReport report, string basePath, char csvSeparator)
        {
            var communityGuestOutput = new StringBuilder();
            communityGuestOutput.AppendLine($"GroupID{csvSeparator}Email");

            foreach (var group in report.Groups)
            {
                if(group.ActiveCommunityGuests != null) { 
                    if(group.ActiveCommunityGuests.Count > 0)
                    {
                        foreach (var guest in group.ActiveCommunityGuests)
                        {
                            communityGuestOutput.AppendLine($"{group.Id}{csvSeparator}{guest}");
                        }
                    }
                }
            }

            Utilities.WriteFile($@"{basePath}\communityguests.csv", communityGuestOutput);
        }

        // Petri Puustinen: Added csvSeparator parameter to control CSV export output separator
        private static void WriteOtherCommunityGuestsReport(AlignmentReport report, string basePath, char csvSeparator)
        {
            var communityGuestOutput = new StringBuilder();
            communityGuestOutput.AppendLine($"GroupID{csvSeparator}Email");

            foreach (var group in report.Groups)
            {
                if (group.OtherCommunityGuests != null)
                {
                    if (group.OtherCommunityGuests.Count > 0)
                    {
                        foreach (var guest in group.OtherCommunityGuests)
                        {
                            communityGuestOutput.AppendLine($"{group.Id}{csvSeparator}{guest}");
                        }
                    }
                }
            }

            Utilities.WriteFile($@"{basePath}\othercommunityguests.csv", communityGuestOutput);
        }

        // Petri Puustinen: Added csvSeparator parameter to control CSV export output separator
        private static void WriteUsersReport(AlignmentReport report, string basePath, char csvSeparator)
        {
            // USERS
            var userOutput = new StringBuilder();
            userOutput.AppendLine(
                $"Email{csvSeparator}Internal{csvSeparator}State{csvSeparator}PrivateFileCount{csvSeparator}PublicMessageCount{csvSeparator}PrivateMessageCount{csvSeparator}LastAccessed{csvSeparator}AAD_State");
            foreach (var user in report.Users)
            {
                Console.WriteLine($"{user.Id}:{user.Email}");

                userOutput.AppendLine(user.GetCsv(csvSeparator));
            }

            Utilities.WriteFile($@"{basePath}\users.csv", userOutput);
        }

        // Petri Puustinen: Added csvSeparator parameter to control CSV export output separator
        private static void WriteGroupsReport(AlignmentReport report, string basePath, char csvSeparator)
        {
            // GROUPS
            var groupOutput = new StringBuilder();

            groupOutput.AppendLine(
                $"Id{csvSeparator}Name{csvSeparator}Type{csvSeparator}PrivacySetting{csvSeparator}State{csvSeparator}MessageCount{csvSeparator}LastMessageDate{csvSeparator}ConnectedToO365{csvSeparator}Memberships.External{csvSeparator}Memberships.Internal{csvSeparator}Uploads.SharePoint{csvSeparator}Uploads.Yammer");
            foreach (var group in report.Groups)
            {
                Console.WriteLine($"{@group.Id}:{@group.Name}");

                groupOutput.AppendLine(@group.GetCsv(csvSeparator));
            }

            Utilities.WriteFile($@"{basePath}\groups.csv", groupOutput);
        }
    }
}