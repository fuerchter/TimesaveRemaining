Time Save Remaining
=================
## What does it do?
Time Save Remaining is a [LiveSplit](http://livesplit.org/) component designed to tell you how much time you can still save during a speedrun. The intention of this is to help you decide whether you should reset or not. This is achieved by adding up all of the Possible Time Save for the remaining segments. There is a component for the Possible Time Save of the current segment built into LiveSplit already, but said component does not have the same effect on your decision-making process.
## How do I install it?
###Without compiling
1. Go to the [releases page](https://github.com/fuerchter/TimesaveRemaining/releases) of the repository.
2. Download the most recent release *.dll file and copy it to your "Components" folder of LiveSplit.
3. Open LiveSplit.
4. Right click and choose "Edit Layout...".
5. Click on the + icon on the left hand side, the list of components will show up.
6. Choose "Time Save Remaining". The component should now be displayed on the timer.

###With compiling
1. Clone the repository.
2. Copy your "LiveSplit.Core.dll" and "UpdateManager.dll" from your LiveSplit to the "LiveSplit.TimesaveRemaining" folder (the one with "LiveSplit.TimesaveRemaining.csproj").
3. Open "LiveSplit.TimesaveRemaining.sln" in Visual Studio.
4. Build the solution.
