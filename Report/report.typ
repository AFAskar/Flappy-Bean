#set text(lang: "en")
#set page("a4", margin: 1in)

#import "Lib/lib.typ": project

#show: project.with(
  title: "Flappy Bean Game Design Document",
  subtitle: "CS458 Game Development Project",
  authors: ("Abdulaziz Fahad BinAskar (443015550)",),
  mentors: ("Dr. Abdullah Ahmed AlOsaimi",),
  branch: "College of Computer and Information Sciences (CCIS)",
  academic-year: "2025/2026",
  features: "fancy-codeblocks",
  footer-text: "IMSIU",
)
= Game Title
Flappy Bean

= Game Idea
Flappy Bean is a side-scrolling endless runner game where the player controls a coffee bean navigating through obstacles. The game is designed to provide a quick, challenging, and addictive experience similar to the classic "Flappy Bird" but with a unique coffee-themed twist. The selection of this game is motivated by the desire to create a simple yet engaging game that appeals to casual gamers and coffee lovers alike.

= Target Audience
The target audience for Flappy Bean includes:
- *Casual Gamers:* Players who enjoy quick sessions of gameplay during breaks or commute.
- *Coffee Enthusiasts:* People who appreciate coffee culture and would find the theme relatable and amusing.
- *Competitive Players:* Gamers who enjoy high-score chasing and challenging their friends.

This audience was selected because the game's mechanics are easy to pick up but hard to master, making it accessible to a wide range of players while offering depth for those who want to compete.

= Game Genre
*Genre:* Endless Runner / Arcade

Flappy Bean falls under the Endless Runner and Arcade genres because:
- *Endless Gameplay:* The game continues indefinitely until the player fails.
- *Score-Based:* The primary goal is to achieve the highest possible score.
- *Simple Controls:* The game uses a single input (tap/click) to control the character.
- *Increasing Difficulty:* The game becomes progressively more challenging as the player advances.

= Character
*Character:* A sentient Coffee Bean.

*Motivation:* The character is a coffee bean who suddenly gained consciousness. The motivation for selecting this character is to create a humorous and relatable protagonist who is trying to escape the fate of being ground and consumed. This adds a layer of narrative and personality to the game.

= Gameplay
The gameplay revolves around navigating the coffee bean through a series of obstacles (pipes) without colliding with them or the ground.

= Challenges
- *Obstacles:* The primary challenge is to fly between pipes that are placed at varying heights.
- *Gravity:* The player must constantly tap to counteract gravity and keep the bean afloat.
- *Precision:* The gap between pipes requires precise timing and control to pass through safely.

= Actions
- *Jump/Flap:* The player can tap the screen or press a key to make the bean flap its "wings" and gain altitude.
- *Fall:* When not flapping, the bean falls due to gravity.

= Challenge Type
- *Skill-Based:* The game relies heavily on the player's reaction time and hand-eye coordination.
- *Endurance:* The challenge is to maintain focus and consistency over time.

#pagebreak()
= Termination Condition
The game ends when:
- The bean collides with a pipe.
- The bean hits the ground.
- The time limit expires.

= Rewards
Rewards are provided to the player to encourage progression and enhance the gameplay experience.

- *Coins:* Players collect coins scattered throughout the level. These can be used to unlock new skins.
- *Medals/Cups:*
    - *Silver Cup:* Awarded for passing a certain number of pipes (e.g., 10).
    - *Gold Cup:* Awarded for passing a higher number of pipes (e.g., 20).
- *Shield:* A power-up that allows the bird to survive crashes for a limited time after collecting a specified number of coins.

= Future Work
To further improve the game, the following features could be added:
- *Suction Pipes:* Introduce pipes that create a vacuum effect, trying to pull the player into them, adding a new layer of difficulty.
- *New Characters:* Add more coffee-themed characters (e.g., Espresso Shot, Cappuccino Foam).
- *Power-ups:* Introduce more power-ups like speed boosts or size reduction.
- *Leaderboards:* Implement a global leaderboard to foster competition among players.

