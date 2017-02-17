# MathsQuestionGenerator

![MQG](https://raw.githubusercontent.com/mullak99/MathsQuestionGenerator/master/MathsQuestionGenerator/Resources/App.png)

An application for generating pseudo-random maths questions.

//TODO - Complete this section.

# Download
The Latest Releases can always be found at either:

http://github.com/mullak99/MathsQuestionGenerator/releases/latest
or
http://builds.mullak99.co.uk/MathsQuestionGenerator/latest

# Usage

- Under 'Clone or Download', Download and extract this Git and run 'MathsQuestionGenerator.sln' with Visual Studio.
- Alternatively, under 'Clone or Download' press 'Open in Visual Studio'.

//TODO - Complete this section.

# Changelog

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
- Fixed log levels greater than 2 being regarded as level 0.
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
