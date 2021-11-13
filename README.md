# osu! Escape

![image](https://user-images.githubusercontent.com/73950784/140847268-7e44ffc3-bf63-4ba8-aff6-c2622d75877a.png)
 
 This project provides osu! score submission blocking, which is conducted by applying the blocking rule in your PC's advanced firewall
 
 **IMPORTANT: This application is only usable if your PC has the firewall enabled!**
 
 ## Inspiration from top osu! players
 
 - [1E308 (Nameless player)'s score submission video (Timestamp to score submission)](https://www.youtube.com/watch?v=D7x7OXpUmss&t=647s&ab_channel=RoriSanbyaku) 
 - [DigitalHypno's disable score submission video](https://www.youtube.com/watch?v=lusAZ1fiph8&ab_channel=DigitalHypno)
 
## Why would players want to play offline? 
 
 - [Spazza17's Fix Negative Mindset in osu! — Start Doing THIS](https://www.youtube.com/watch?v=cEyVSiY9ohU&ab_channel=Spazza17)
 
 It is proven by the osu! community that players could perform better without focusing on score leaderboards (global, country, and friends rankings) while being able to upload scores.
 
 ## Features
 
 This application is currently available on osu! standard except osu! lazer 
 
 - Global Toggle Key: Toggle the connection using the F6 Key
 - Score Details/ Map Details display ([ProcessMemoryDataFinder](https://github.com/Piotrekol/ProcessMemoryDataFinder) by Piotrekol)
 - Auto submission: Before switching to the results screen, if the *"full combo"* scores meet the requirement inputted by user, it would automatically connect back to the server for uploading scores
 - Auto blocking: Disconnect from the server after uploading the recent score (API needed)
 
 *Dropping slider ends still count as a "full combo"

## Why API is needed for this application? Is it safe?
 
 - This application uses osu! API v1 to get your recent uploaded score (get_user_recent) and automatically disconnect after uploading
 - For users who is concerned about the API usage, please feel free to not use it :D
 
 
 Thank you to those who contributed to this project (Listed in ascending order by osu! IGN):
 
 Testing: Hellotomlol225, Muji, Surac, Takanashi Ako
 
 Coding: Shion Maker
