namespace Dawn.Apps.StartupManager.Utilities;

using System.Collections.Generic;

public class CleanupEntryComparer : IEqualityComparer<CleanupEntry>
{
    public bool Equals(CleanupEntry x, CleanupEntry y) => x?.ToString() == y?.ToString();

    public int GetHashCode(CleanupEntry obj) => obj.ToString().GetHashCode();
}