#VAR snitch = false
#VAR cover = false
VAR player_name = "Lydia"
How is it going? #Received
{player_name}? #Received
* To XxyzxX: A little behind#Sent
-> start_char2
* To XxyzxX: Nearly there#Sent
->start_char2
* To XxyzxX: Nearly there#Sent
->start_char2

==start_char2==
Lucifer to you: I need to talk to you about something#Received
->char2_01


==char2_01==
* I haven't got time#Sent 
-> char2_plead
+ What's up?#Sent
-> char2_02

==char2_02==
I can't find the notes#Received
->END

==char2_plead==
Please it's really important#Received
->char2_01





