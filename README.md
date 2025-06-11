# JobAA
Console App that autoruns job search, cover writing in my voice and Application filling and cv tweaking

Nuget Packages required: 
HtmlAgilityPack  # For scraping
Selenium.WebDriver # For JS-heavy sites
Newtonsoft.Json  # For storing jobs

Basic Scraper will take care of simpler sites like Indeed while I will need to create another function to handle sites with heavier use of JS like LinkedIn. 
Classes
-JobScraper
    Funcs
    - ScrapeSite(string keyword)
    - ScrapeAdvancedSite (JS Heavy sites will use Selenium)
-CoverLetterGenerator
    Funcs
    - Ctor(apikey) 
    - GenerateCoverLetter(Task)(JobListing j, string myCV){will build a prompt to pass to chatGPT using the details for the JobListing i.e. job.Title, job.description, job.Company and my most recent cv}
        
-JobApplicator(Selenium Webdriver, Support)
    Funcs
    -ApplyToJob(JobListing,string coverLetter)


Bring classes together in Program.cs
create variables for the job Scraping task, the Users CV and a ai which will hold the openAI key.
Use Foreach to cycle through jobs (Try/Catch for expected failures on applications)
Take note of job applied for an back up to report. 

Remember to consider: 
- Bans (Rate limits add thread sleep actions)
- Will consider larger scale once poc is created and tested (Luminati)
- Try and create a save failed applications for later function
- When using in production ensure to use --headless browsing or else suffer being found out. If sites are still alerted to your gambit try using --undetected-chromedriver
          Also consider the following to make yourself out to be a real user
          --disable-gpu
          --window-size=1920,1080
          --ignore-certificate-errors
          --disable-extensions
          --no-sandbox
          --disable-dev-shm-usage  


    POSSIBLE NEXT STEPS:
  Back Up Report to .csv
  Add more websites
  Add More filters to stipulate SalaryRange, remote-Only etc
