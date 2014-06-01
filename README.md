Time Save Remaining
=================
## What does it do?
Time Save Remaining is a [LiveSplit](http://livesplit.org/) component designed to tell you how much time you can still save during a speedrun. The intention of this is to help you decide whether you should reset or not. This is achieved by adding up all of the Possible Time Save for the remaining segments. There is a component for the Possible Time Save of the current segment built into LiveSplit already, but said component does not have the same effect on your decision-making process.
## How do I install it?
(If you don't want to compile the "LiveSplit.TimesaveRemaining.dll" yourself you can get it from [here](https://www.dropbox.com/s/k0bc7t2t5ygy6vz/LiveSplit.TimesaveRemaining.zip) for now. Doing that you can skip to step 6.)

1. Clone the repository.
2. If you haven't already: Download [LiveSplit](http://livesplit.org/).
3. Copy your "LiveSplit.Core.dll" and "UpdateManager.dll" from your LiveSplit to the "LiveSplit.TimesaveRemaining" folder (the one with "LiveSplit.TimesaveRemaining.csproj").
4. Open "LiveSplit.TimesaveRemaining.sln" in Visual Studio.
5. Build the solution.
6. The "LiveSplit.TimesaveRemaining.dll" should now be located in "./LiveSplit.TimesaveRemaining/bin/Debug". Copy it to the "Components" folder of LiveSplit.
7. Open LiveSplit.
8. Right click and choose "Edit Layout...".
9. Click on the + icon on the left hand side, the list of components will show up.
10. Choose "Time Save Remaining". The component should now be displayed on the timer.
