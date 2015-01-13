﻿using NuGet.PackagingCore;
using NuGet.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGet.PackageManagement.UI
{
    public class PreviewResult
    {

        // TODO: hook this up to PM
        public IEnumerable<PackageIdentity> Deleted
        {
            get;
            private set;
        }

        public IEnumerable<PackageIdentity> Added
        {
            get;
            private set;
        }

        public IEnumerable<PackageIdentity> Unchanged
        {
            get;
            private set;
        }

        public IEnumerable<UpdatePreviewResult> Updated
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public NuGetProject Target
        {
            get;
            private set;
        }

        public PreviewResult(
            NuGetProject target,
            IEnumerable<PackageIdentity> added,
            IEnumerable<PackageIdentity> deleted,
            IEnumerable<PackageIdentity> unchanged,
            IEnumerable<UpdatePreviewResult> updated)
        {
            string s = null;
            if (target.TryGetMetadata<string>("ProjectName", out s))
            {
                Name = s;
            }
            else
            {
                Name = "Unknown Project";
            }

            Added = added;
            Deleted = deleted;
            Unchanged = unchanged;
            Updated = updated;
        }
    }
}
