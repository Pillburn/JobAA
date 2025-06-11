using System;
using HtmlAgilityPack;

namespace JobAA;

public class JobScraper
{
    public static List<JobDescription> ScrapeSite(string keyword)
    {
        //For scraping Indeed and sites like it.
        //Indeed for testing purposes init
        //we create a variable(jobs) to hold a new list of jobDescriptions
        var jobs = new List<JobDescription>();
        //then we create a variable to hold the url for the job site as well as using Uri.EscapeDataString which ensure any # () characters are ignored
        var url = $"https://indeed.com/jobs?q={Uri.EscapeDataString(keyword)}";
        var web = new HtmlWeb();
        var doc = web.Load(url);
        foreach (var node in doc.DocumentNode.SelectNodes("//div[contains(@class, 'job_seen_beacon')]"))
        {
            jobs.Add(new JobDescription
            {
                Title = node.SelectSingleNode(".//h2/a").InnerText.Trim(),
                Company = node.SelectSingleNode(".//span[contains(@class, 'companyName')]").InnerText.Trim();
                Link = "https://indeed.com" + node.SelectSingleNode(".//h2/a").GetAttributeValue("href", ""),
                Description = node.SelectSingleNode(".//div[contains(@class, 'job-snippet')]").InnerText.Trim()
            });
        }
        return jobs;
    }
}

public class JobDescription()
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Company { get; set; }

    public string Link { get; set; }    
}
