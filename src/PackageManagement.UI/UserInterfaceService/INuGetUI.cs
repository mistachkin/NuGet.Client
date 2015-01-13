﻿using NuGet.Client;
using NuGet.PackagingCore;
using NuGet.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NuGet.PackageManagement.UI
{
    /// <summary>
    /// The NuGet package management UI
    /// </summary>
    /// <remarks>This is not expected to be thread safe.</remarks>
    public interface INuGetUI
    {
        bool PromptForLicenseAcceptance(IEnumerable<PackageLicenseInfo> packages);

        void LaunchExternalLink(Uri url);

        void LaunchNuGetOptionsDialog();

        /// <summary>
        /// Displays the preview window with options to accept or cancel
        /// </summary>
        bool PromptForPreviewAcceptance(IEnumerable<PreviewResult> actions);

        /// <summary>
        /// Opens the progress window
        /// </summary>
        void ShowProgressDialog(DependencyObject ownerWindow);

        /// <summary>
        /// Closes the progress window
        /// </summary>
        void CloseProgressDialog();

        /// <summary>
        /// Returns the logging context of the ProgressWindow
        /// </summary>
        INuGetProjectContext ProgressWindow { get; }

        /// <summary>
        /// Target projects
        /// </summary>
        IEnumerable<NuGetProject> Projects { get; }

        /// <summary>
        /// True if the option to preview actions first is checked
        /// </summary>
        bool DisplayPreviewWindow { get; }

        /// <summary>
        /// The current user action to perform
        /// </summary>
        UserAction UserAction { get; }

        /// <summary>
        /// Package currently selected in the UI
        /// </summary>
        PackageIdentity SelectedPackage { get; }

        /// <summary>
        /// Displays a modal dialog with the error message
        /// </summary>
        void ShowError(string message, string detail);

        /// <summary>
        /// File conflict option
        /// </summary>
        FileConflictAction FileConflictAction { get; }

        /// <summary>
        /// Refreshes the package details and installed status icons
        /// </summary>
        void RefreshPackageStatus();

        SourceRepository ActiveSource { get; }
    }
}
