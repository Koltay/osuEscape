# osu! Escape
![image](https://user-images.githubusercontent.com/73950784/144431649-48b10f29-f2ee-4e28-a373-d7db5e070328.png)

![image](https://user-images.githubusercontent.com/73950784/144431804-574c08c8-868f-4393-9362-6173a533fcb7.png)

![image](https://user-images.githubusercontent.com/73950784/144431910-b4650e39-5aea-45f3-93aa-c5c953d83e4c.png)
 
 This project provides osu! score submission blocking, which is conducted by applying the blocking rule in your PC's advanced firewall
 
 **IMPORTANT: This application is only usable if your PC has the firewall enabled!**
 
 ## Inspiration from top osu! players
 
 - [1E308 (Nameless player)'s score submission video (Timestamp to score submission)](https://www.youtube.com/watch?v=D7x7OXpUmss&t=647s&ab_channel=RoriSanbyaku) 
 - [DigitalHypno's disable score submission video](https://www.youtube.com/watch?v=lusAZ1fiph8&ab_channel=DigitalHypno)
 
## The purpose of playing offline
 
 - [Spazza17's Fix Negative Mindset in osu! — Start Doing THIS](https://www.youtube.com/watch?v=cEyVSiY9ohU&ab_channel=Spazza17)
 
 It is proven by the osu! community that players could perform better without focusing on score leaderboards (global, country, and friends rankings) 
 
 While playing "offline" using osu!Escape, players would be able to upload scores with better performance.
 
 ## Features
 
 This application is currently available on osu! standard except osu! lazer 
 
 - **Global Toggle Key:** 
 > Toggle the connection using the F6 Key (Changeable, supports multiple modifier keys)
 
 - **Score Details/ Map Details display** 
 > [ProcessMemoryDataFinder](https://github.com/Piotrekol/ProcessMemoryDataFinder) by Piotrekol
 
 - **Auto Submission:** 
 > After players hit the last note of the beatmap, *"full combo"* score meeting the requirement would be submitted 
  
 > The score would be submitted to the server while players are on the results screen
 
 - **Auto Blocking:** 
 > Automatically disconnect players from the server after uploading the recent score (API needed)
 
 > Auto blocking also avoid uploading other scores by the players
 
 *Dropping slider ends still count as a "full combo"

## API Usage and users' common concern
 
 This application uses [osu! API v1](https://github.com/ppy/osu-api/wiki) to get users' recent uploaded score and automatically disconnect after uploading.
 
 As for the users who are concerned about the API usage, please feel free to not use it :D

## Video Showcase

There will be a video showcase after the new UI is completed!

## Ways to check if the firewall rule is working

Win + R and type "wf.msc" in "Run" box

![image](https://user-images.githubusercontent.com/73950784/145205485-2d47cb8d-14a2-44d9-b534-e79efaf6cc9b.png)

There should be "osu block" rule enabled while blocking the connection

![firewall rule](https://user-images.githubusercontent.com/73950784/145205745-baa4cc17-292f-4b01-a313-8fa8abc6add0.png)


## <3
 Thank you to those who gave positive feedback or contributed to this project (Listed in ascending order by osu! IGN):
 
 Testing: 
 - Hellotomlol225
 - Muji
 - Surac
 - Takanashi Ako
 
 Coding: 
 - DenierNezzar
 - Shion Maker
 
 ## Licenses
 The following projects are used in osu!Escape:
 - [ProcessMemoryDataFinder](https://github.com/Piotrekol/ProcessMemoryDataFinder), [GPL-3.0](https://github.com/Piotrekol/ProcessMemoryDataFinder/blob/master/LICENSE)
