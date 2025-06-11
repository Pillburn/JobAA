# JobAA

A console application that automates job searching, cover letter generation (in your voice), application filling, and CV tweaking.

## Features
- **Automated Job Scraping**: Handles both simple sites (Indeed) and JS-heavy sites (LinkedIn).
- **AI-Powered Cover Letters**: Generates tailored cover letters using OpenAI.
- **Automated Applications**: Fills and submits job applications using Selenium.
- **Failure Handling**: Logs failed applications for later review.

## NuGet Packages Required
- `HtmlAgilityPack` – For scraping basic sites.
- `Selenium.WebDriver` – For JS-heavy sites.
- `Newtonsoft.Json` – For storing job data.

## Architecture
### Classes & Functions
#### **JobScraper**
- `ScrapeSite(string keyword)` – Handles simple sites (e.g., Indeed).
- `ScrapeAdvancedSite()` – Uses Selenium for JS-heavy sites (e.g., LinkedIn).

#### **CoverLetterGenerator**
- `Constructor(apiKey)` – Initializes OpenAI API key.
- `GenerateCoverLetter(JobListing j, string myCV)` – Builds a GPT prompt using job details (`Title`, `Description`, `Company`) and your CV.

#### **JobApplicator** (Selenium WebDriver)
- `ApplyToJob(JobListing, string coverLetter)` – Automates job application submission.

### **Program.cs Workflow**
1. Initialize variables:
   - Job scraping task.
   - User’s CV.
   - OpenAI API key.
2. Loop through jobs using `foreach` (with `try/catch` for expected failures).
3. Log applied jobs for reporting.

## Considerations
- **Rate Limits**: Add `Thread.Sleep()` to avoid bans.
- **Stealth Mode** (for production):
  ```bash
  --headless --disable-gpu --window-size=1920,1080 --ignore-certificate-errors --disable-extensions --no-sandbox --disable-dev-shm-usage
