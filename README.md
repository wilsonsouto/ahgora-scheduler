&#xa0;

<h1 align="center">Ahgora Scheduler</h1>

<p align="center">
  <img alt="Github top language" src="https://img.shields.io/github/languages/top/wilsonsouto/ahgora-scheduler?color=56BEB8">

  <img alt="Github language count" src="https://img.shields.io/github/languages/count/wilsonsouto/ahgora-scheduler?color=56BEB8">

  <img alt="Repository size" src="https://img.shields.io/github/repo-size/wilsonsouto/ahgora-scheduler?color=56BEB8">

  <img alt="License" src="https://img.shields.io/github/license/wilsonsouto/ahgora-scheduler?color=56BEB8">
</p>

<p align="center">
  <a href="#dart-about">About</a> &#xa0; | &#xa0; 
  <a href="#sparkles-features">Features</a> &#xa0; | &#xa0;
  <a href="#rocket-technologies">Technologies</a> &#xa0; | &#xa0;
  <a href="#white_check_mark-requirements">Requirements</a> &#xa0; | &#xa0;
  <a href="#checkered_flag-starting">Starting</a> &#xa0; | &#xa0;
  <a href="#memo-license">License</a> &#xa0; | &#xa0;
  <a href="https://github.com/wlsonsouto" target="_blank">Author</a>
</p>

<br>

## :dart: About

This script was created to automate time tracking for work, addressing the common issue of forgetting to clock in and out. Using Selenium and a task scheduler, it ensures accurate and reliable time logging, providing a hands-free solution for managing work hours.

## :sparkles: Features

:heavy_check_mark: **Automated Time Tracking**: Register work hours with a single execution.\
:heavy_check_mark: **Scheduled Operations**: Runs at specified times using task schedulers, eliminating manual input.\
:heavy_check_mark: **Reliable Accuracy**: Ensures precise time tracking, reducing human errors.

## :rocket: Technologies

The following tools were used in this project:

- .NET 8.0
- C#
- Selenium

## :white_check_mark: Requirements

Before starting :checkered_flag:, you need to have [Git](https://git-scm.com) and [.NET SDK](https://dotnet.microsoft.com/en-us/download) installed.

## :checkered_flag: Starting

### Step 1: Set up the project

```bash
# Clone this project
$ git clone https://github.com/wilsonsouto/ahgora-scheduler

# Access the project folder
$ cd ahgora-scheduler/AhgoraScheduler

# Create a .env file
$ touch .env

# Add the following content to .env
SITE_URL="your-ahgora-website"
USER_REGISTRATION="your-registration"
USER_PASSWORD="your-password"

# Replace your-ahgora-website, your-registration, and your-password with your credentials
```

### Step 2: Set up a schedule task

**Windows:**

```ini
# Open Task Scheduler
# Create a new task and give it a meaningful name
# Under the Actions tab, select Start a Program
# In Program/script, click Browse and select AhgoraScheduler.exe from bin/Release/net8.0
# Configure the Trigger (time or frequency) according to your scheduling needs
# Save the task and ensure it runs correctly
```

**Linux/macOS:**

```bash
# Open a terminal and run
$ crontab -e

# Add a new line to schedule the script (e.g., run every day at 8 AM)
$ 0 8 * * * /path/to/AhgoraScheduler/bin/Release/net8.0/AhgoraScheduler

# Save the file and exit the editor

# Verify the scheduled task
$ crontab -l
```

## :memo: License

This project is under license from MIT. For more details, see the [LICENSE](LICENSE) file.

Made with :heart: by [wilsonsouto](https://github.com/wilsonsouto)

&#xa0;

<a href="#top">Back to top</a>
