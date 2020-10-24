using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace GithubRestApiTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var githubClient=new GitHubClient(new ProductHeaderValue("my-cool-app"));
            // Initialize a new instance of the SearchRepositoriesRequest class
//            var request = new SearchRepositoriesRequest();

            // you can also specify a search term here
            var request = new SearchRepositoriesRequest()
{
    // lets find a library with over 1k stars
    // Stars = Range.GreaterThan(1000),

    // we can specify how big we want the repo to be in kilobytes
    // Size = Range.GreaterThan(1),

    // maybe we want the library to have over 50 forks?
    // Forks = Range.GreaterThan(50),

    // we may want to include or exclude the forks too
    // Fork = ForkQualifier.IncludeForks,

    // how about we restrict the language the library is written in?
    //Language = Language.CSharp,

    // maybe we want to include searching in the read me?
    // In = new[] { InQualifier.Readme },

    // or go all out and search the readme, name or description?
    // In = new[] { InQualifier.Readme, InQualifier.Description, InQualifier.Name },

    // how about searching for libraries created after a given date?
    // Created = DateRange.GreaterThan(new DateTime(2015, 1, 1)),

    // or maybe check for repos that have been updated between a given date range?
    // Updated = DateRange.Between(new DateTime(2012, 4, 30), new DateTime(2012, 7, 4)),

    // we can also restrict the owner of the repo if we so wish
    User = "therealmaqsood"
};

            var result = await githubClient.Search.SearchRepo(request);
            foreach (var item in result.Items)
            {
                Console.WriteLine(item.Description);
                Console.WriteLine($"\tLanguage : {item.Language}");
                Console.WriteLine($"\tStars : {item.StargazersCount}");
                Console.WriteLine($"\tLicense : {item.License}");
                Console.WriteLine($"\tUpdated : {item.UpdatedAt}");
             
            }
            Console.ReadLine();
        }
    }
}
