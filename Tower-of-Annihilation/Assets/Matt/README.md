## Matt - AI Specialist

### Patrol 

* Move NPC in random directions
* Take time for NPC to rest (idle)
* Interact with enemy script to check if NPC is interacting with player
* Checks collision with box collider to determine if hitting a wall and change direction

### Enemy

* Uses raycast to check if player is in 'agrorange' and will chase player if true
* Uses 'moveto' function to chase player
* Bool function checks if NPC is chasing to check if NPC should resume patrol
