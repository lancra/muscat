using Microsoft.Extensions.Hosting;

namespace Muscat;

public static class DatabaseLocationProvider
{
    public static Uri ResolvePath(IHostEnvironment env)
    {
        ArgumentNullException.ThrowIfNull(env);

        var userApplicationDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var directory = Path.Join(userApplicationDataPath, "muscat");

        if (env.IsDevelopment())
        {
            var assembly = typeof(DatabaseLocationProvider).Assembly;
            directory = Path.GetDirectoryName(assembly.Location);
        }

        var pathString = Path.Join(directory, "muscat.db");
        return new Uri(pathString);
    }
}
