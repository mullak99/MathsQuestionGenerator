# MathsQuestionGenerator

![MQG](https://raw.githubusercontent.com/mullak99/MathsQuestionGenerator/master/MathsQuestionGenerator/Resources/App.png)

An application for generating pseudo-random maths questions.

//TODO - Complete this section.

## Download

### Installer

//TODO - Currently in development.

### Portable

| Location  | Download |
| :-------------: | :-------------: |
| Personal Server  | [Direct](http://builds.mullak99.co.uk/MathsQuestionGenerator/latest) |
| Github Releases  | [Direct](http://github.com/mullak99/MathsQuestionGenerator/releases/latest) |

## Application Usage

### Launch Parameters

Launch Parameters can be used to launch the program with tweaked settings or features. They can be used by running the program from command prompt using `"Maths Question Generator.exe" --<param>`, creating a shortcut with the parameter at the end of the Target field or by creating a `launchParams.cfg` in the config folder. Here's a list of current launch parameters:

- `--offline` or `-o`: Launches the program in Offline Mode (All internet related code disabled).
- `--developer` or `-d`: Launches the program in developer mode, this allows access to debugging tools.
- `--cleanUpdates` or `-c`: Performs a clean update when an update is availible, best used in the config file or shortcut.
- `--update` or `-u`: Forcibly downloads and installs the latest version.

//TODO - Complete this section.

## Usage of the source code

- Under 'Clone or Download', Download and extract this Git and run 'MathsQuestionGenerator.sln' with Visual Studio.
- Alternatively, under 'Clone or Download' press 'Open in Visual Studio'.

## Changelog

|---| 1.0.0.0 |---|

- Initial Release

|---| 1.0.1.0 |---|

- Added a timer
- Added a start screen
- Added an Exit option
- Added a 'Custom', user-defined, difficulty option
- Added a developer option to autofill all answers
- Added a developer option to find the max difficulty setting
- Added comments to the source code
- Added a difficulty limit of 536870911
- Added a developer option to silence non-warning/error logs from the console
- Updated the copyright information year
- Changed the copyright information to reflect the GPL 3.0 licence
- Changed the colour of the program to Dark Blue
- Changed the colour of the Submit button to Lime
- Changed the colour of the Reset button to Yellow
- Changed the button styles to Flat
- Neatened the code
- Fixed a crash where the custom difficulty was set to 0
- Fixed a crash where text was pasted into the custom difficulty

|---| 1.0.1.1 |---|

- Added About form
- Removed unused resource

|---| 1.0.2.0 |---|

- Added difficulty triggers on the start splash screen
- Added a cooldown (5 sec) on the reset button whenever generating new questions
- Added a developer option to force a reset (Bypass 5 second cooldown)
- Added a developer option to force the startup splash screen
- Added keyboard shortcuts to all menu items
- Added a submit menu item
- Added/Split the reset options in the menu to include a normal reset and a complete reset (Normal+Stats Reset)
- Added a shortcut to the reset button (Holding Shift when clicking) to do a complete reset (Normal+Stats Reset)
- Changed the colour scheme of the developer console to match the main window
- Removed the timer, progress bar, reset button and 2dp note from the startup splash screen

|---| 1.0.3.0 |---|

- Added a Check for Updates feature that runs on app start
- Added an Update Page to contain detailed update information
- Added a popup if you are on an old version of MQG
- Added a Help menu item (Moves 'About' into the 'Help' menu)
- Added a developer option to change the timers tick rate
- Added a developer option to auto-answer questions
- Added a 'DEV' logging level for logs created by 'cheaty' developer options
- Added a Version Spoofer
- Fixed resetting after submitting answers not increasing the total number of answers you could have correct
- Fixed log levels greater than 2 being regarded as level 0
- Fixed changing start splash screen difficulty not updating 'File > New' difficulty checkmarks
- Fixed some abbreviations
- Replaced the console 'Close' button with a 'Clear' button to empty the console
- Changed the buttons to a 'Popup' style
- Changed the Start/Submit/Next button shortcut
- Changed the logging levels (0 = Default, 1 = DEV, 2 = WARN, 3 = ERROR)
- Allowed for the changing of the Submit menu item text, it now syncs with the text on the button
- Reworked the watermark/ghost text in the guess textboxes to make it more reliable
- Removed nextBoard() and replaced all instances with reset(), it wasn't necessary with the 'submit-reset' bugfix
- Removed unneeded globalDifficulty writes, replaced them with setDifficulty()

|---| 1.0.3.1 |---|

- Added a check to stop "Developer Mode has been enabled!" being posted multiple times each log
- Fixed a bypass for spoofing a server error and another version simultaneously (Enabling Server Error spoof, then selecting another version spoof)

|---| 1.0.3.2 |---|

- Fixed a crash when checking for an update (and on launch) when the user does not have an internet connection

|---| 1.0.3.3 |---|

- Fixed the broken updater (Example: Version v1.0.0.1 would be classified as newer than v1.0.1.0)

|---| 1.0.4.0 |---|

- Added a full auto-updater
- Added an Offline Mode
- Added a simple saving of session statistics
- Added the ability to use launch parameters
- Added a launch parameter to open into Offline Mode
- Added a launch parameter to open enable an easter egg
- Added a launch parameter to enable developer mode
- Added a warning to Auto-Filling Answers above 100000 difficulty
- Added an option to export a log file from normal user mode
- Added a developer option to toggle offline mode
- Changed the Server Error console message to a WARN status
- Changing difficulty now resets statistics
- Aligned the Latest Version and Current Version numbers
- Compacted the Check for Update code
- Removed the developer mode 'secret' toggle
- Fixed the total correct this session being increased early

|---| 1.0.4.1 |---|

- Added a launch parameter to do clean updates
- Changed the 'Download Update' button text to 'Update MQG'
- Changed the Update popup message to reflect the 'Update MQG' button text
- Added an optional config folder, this will be used more at a later date
- Moved 'launchParams.cfg' load location to the config folder
- Fixed Average Time counter when at difficulties greater than Medium (20)

|---| 1.0.4.2 |---|

- Added support for full installs

|---| 1.0.4.3 |---|

- Fixed updating application when in an admin-protected directory

|---| 1.0.4.4 |---|

- Fixed updating application without the 'Documents/mullak99/Maths Question Generator' folder.