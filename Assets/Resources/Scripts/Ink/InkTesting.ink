VAR lied_for_fried = false
VAR player_name = "Lydia"
* Hi {player_name}, how is the report coming along?#Received
-> start_char1
*I need to talk to you about something#Received
->start_char2
*Hey {player_name}, going out tonight?#Received
->start_char3

==start_char1==
* A little behind#Sent
-> END
*Nearly there#Sent
->END

==start_char2==
* I haven't got time#Sent 
-> END
* What's up?#Sent
-> END

==start_char3==
* No#Sent
->awkward_char3
* I am not and neither should you#Sent
->awkward_char3
* What the hell is wrong with you?!#Sent
->awkward_char3
==awkward_char3==
You need to chill#Received 
->END