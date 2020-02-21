#VAR snitch = false
#VAR cover = false
VAR player_name = "Lydia"
To you means you're the only person who can see the message
XxyzxX to you: Hi {player_name}, how is the report coming along?#Received
-> start_char1

==start_char1==
* To XxyzxX: A little behind#Sent
-> start_char2
* To XxyzxX: Nearly there#Sent
->start_char2

==start_char2==
Lucifer to you: I need to talk to you about something#Received
->char2_01


==char2_01==
* I haven't got time#Sent 
-> char2_02
+ What's up?#Sent
-> char2_03

==char2_02==
Luficer to you: please, it's important#Received
-> char2_01

==char2_03==
Luficer to you: I can't find the notes we made after the last lecture#Received
->start_char3


==start_char3==
Mothy to you: Hey {player_name}, going out tonight?#Received
->start_char3

==char3_01==
* To Mothy: No#Sent
->END
* To Mothy: I am not and neither should you#Sent
->END
* To Mothy: What the hell is wrong with you?!#Sent
->END
==char3_02==
*I'm telling the rest of the group asap->snitch
*I'll cover for you->cover

==snitch==
Mothy lost the notes guys :(#Sent
->END

==cover==
To Lucifer: I don't know where they are :/#Sent
->END



