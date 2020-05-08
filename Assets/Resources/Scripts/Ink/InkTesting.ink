#VAR snitch = false
#VAR cover = false
VAR player_name = "Lydia"
VAR char_1 = "AngryPanda"
VAR char_2 = "Mike"
VAR char_3 = "Ghux'o"

{char_1}: How is it going? #Received
{player_name}? #Received
* A little behind#Sent
-> start_char2
* Nearly there#Sent
->start_char2
* Nearly there#Sent
->start_char2

==start_char2==
{char_2} to you: I need to talk to you about something#Received
->char2_01


==char2_01==
* To {char_2}: I haven't got time#Sent 
-> char2_plead
+ To {char_2}: What's up?#Sent
-> char2_02

==char2_02==
{char_2} to you: I can't find the notes#Received
->END

==char2_plead==
{char_2} to you: Please it's really important#Received
->char2_01





