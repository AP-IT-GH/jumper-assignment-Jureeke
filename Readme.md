# ML Agent Jumper

#### Namen:
- Vincent Juré
- Tijn Wagenmakers

#### Doel:
Agent moet over het obstakel kunnen springen.

### 

------------

### Werkwijze:
#### Set-up: 
Simpele omgeving waarbij de agent over een obstakel moet springen. Aan het einde van de track bevind zich een muur. Deze is er voor te weten of de agent over het obstakel is gesprongen of niet.

![Set-up](https://media.discordapp.net/attachments/1233425529009471508/1233425988420108320/Schermafbeelding_2024-04-26_om_16.34.04.png?ex=662d0cf7&is=662bbb77&hm=6790f496a0ed4b7dc0db720e79aaf54a34a7edb30c8a593335a73ebd0546f8de&=&format=webp&quality=lossless&width=1860&height=886 "Set-up")

#### Agent reward function:
- De agent krijgt een grote negatieve reward wanneer die het obstakel raakt **Reward (-1.0f)**
- De agent krijgt een lage reward wanneer die aan de grond blijft. (Zo springt de agent niet steeds) **Reward (0.2f)**
- De agent krijgt een middelgrote reward wanneer het obstakel de muur raakt.  **Reward (0.4f)**

#### Behavior Parameters:
* Vector Observation space: 0
* Actions: 1 discrete action Branch, met 2 acties: springen en niets doen

#### Config:
jumper.yaml: 
https://learning.ap.be/tokenpluginfile.php/4bc48d334b33f5431527167e4fa40921/2381548/mod_forum/post/267257/jumper.yaml

#### Training:

We hebben het verschillende keren laten trainen met nieuwe parameters of andere rewards. De laaste training doet die het beste wat het moet doen.

##### Tensorboard:
![Tensorboard](https://media.discordapp.net/attachments/1233425529009471508/1233425619337871460/Schermafbeelding_2024-04-26_om_16.22.09.png?ex=662d0c9f&is=662bbb1f&hm=5716f5333e99df1c79bebf8072240d548fcbf7b683a9de1a651335421d6d511f&=&format=webp&quality=lossless&width=1210&height=1424 "Tensorboard")

### 
------------
### Conclusie:
Na 200.000 stappen te laten trainen springt de agent vrij goed over de obstakels. Alleen wanneer er 2 kort na elkaar komen dan heeft die het soms lastig vanwege niet genoeg tijd te hebben om te kunnen springen
