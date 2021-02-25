using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCSharpPart1
{
    
    class standardWarrior
    {
        public int standardWarriorHealth;
        public int currentWarriorHealth;

        public standardWarrior(int minWarriorHealth, int maxWarriorHealth)
        {
            Random choosingOurWarriorHealth = new Random();
            
            standardWarriorHealth = choosingOurWarriorHealth.Next(minWarriorHealth, maxWarriorHealth);
            currentWarriorHealth = standardWarriorHealth;
        }
        public short createWarriorDamageStats(float inputDmgRatioChanger)
        {
            Random choosingRandWarriorDmgFactor = new Random();
            int lookingForMaxDivider = 1;
            //chooses what is value is bigger than the health of the unit but it also needs to be the smallest possible power of 10
            for (lookingForMaxDivider = 1; lookingForMaxDivider < standardWarriorHealth; lookingForMaxDivider = lookingForMaxDivider * 10) { }

            float balancerOfHealthToDmg = (float)((1 - ((double)standardWarriorHealth / lookingForMaxDivider)) * choosingRandWarriorDmgFactor.NextDouble()) * lookingForMaxDivider;

            byte cycleSearchRandSearchDmg = 0;
            while ((balancerOfHealthToDmg < standardWarriorHealth / 40 || balancerOfHealthToDmg > standardWarriorHealth / 10) && cycleSearchRandSearchDmg<100)
            {
                balancerOfHealthToDmg = (float)((1 - ((double)standardWarriorHealth / lookingForMaxDivider)) * choosingRandWarriorDmgFactor.NextDouble()) * lookingForMaxDivider;
                cycleSearchRandSearchDmg++;
            }



            return (short)(balancerOfHealthToDmg*16*inputDmgRatioChanger);


        }
        public short createWarriorDefenseStats(float inputDfnRatioChanger)
        {
            Random choosingRandWarriorDfnFactor = new Random();
            int lookingForMaxDividerDfn = 1;
            //chooses what is value is bigger than the health of the unit but it also needs to be the smallest possible power of 10
            for (lookingForMaxDividerDfn = 1; lookingForMaxDividerDfn < standardWarriorHealth; lookingForMaxDividerDfn = lookingForMaxDividerDfn * 10) { }

            float balancerOfHealthToDfn = (float)((1 - ((double)standardWarriorHealth / lookingForMaxDividerDfn)) * choosingRandWarriorDfnFactor.NextDouble()) * lookingForMaxDividerDfn;

            byte cycleSearchRandSearchDfn = 0;
            while ((balancerOfHealthToDfn < standardWarriorHealth / 40 || balancerOfHealthToDfn > standardWarriorHealth / 15) && cycleSearchRandSearchDfn < 100)
            {
                balancerOfHealthToDfn = (float)((((double)standardWarriorHealth / lookingForMaxDividerDfn)) * choosingRandWarriorDfnFactor.NextDouble()) * lookingForMaxDividerDfn;
                cycleSearchRandSearchDfn++;
            }



            return (short)(balancerOfHealthToDfn * 16 * inputDfnRatioChanger);


        }
        public short createWarriorHealStats(float inputHealRatioChanger)
        {
            Random choosingRandWarriorHealFactor = new Random();
            int lookingForMaxDividerHeal = 1;
            //chooses what is value is bigger than the health of the unit but it also needs to be the smallest possible power of 10
            for (lookingForMaxDividerHeal = 1; lookingForMaxDividerHeal < standardWarriorHealth; lookingForMaxDividerHeal = lookingForMaxDividerHeal * 10) { }

            float balancerOfHealthToHeal = (float)((1 - ((double)standardWarriorHealth / lookingForMaxDividerHeal)) * choosingRandWarriorHealFactor.NextDouble()) * lookingForMaxDividerHeal;

            byte cycleSearchRandSearchHeal = 0;
            while ((balancerOfHealthToHeal < standardWarriorHealth / 40 || balancerOfHealthToHeal > standardWarriorHealth / 15) && cycleSearchRandSearchHeal < 100)
            {
                balancerOfHealthToHeal = (float)((((double)standardWarriorHealth / lookingForMaxDividerHeal)) * choosingRandWarriorHealFactor.NextDouble()) * lookingForMaxDividerHeal;
                cycleSearchRandSearchHeal++;
            }

            
            
            
            return (short)(balancerOfHealthToHeal * 16 * inputHealRatioChanger);
            

        }
        
    }
    public class Room
    {
        public bool north;
        public bool east;
        public bool south;
        public bool west;
        public bool playerPresenceCheck;

        
        //the following boolean variable is iunvolved in the labyrinth game generator as marker if this room has been visted by the 'generator selector' to prevent rooms getting doublecheked which might lead in peroformnace problems and logical coding problems
        // watch to understand why i made the following boolean https://www.youtube.com/watch?v=PMMc4VsIacU 
        public bool checkForDoorOpeningStability;
        public Room(bool northernRoomOpening, bool easternRoomOpening, bool southernRoomOpening, bool westernRoomOpening, bool playerOccupationRoom, bool roomBeenVisited)
        {
            north = false;
            east = false;
            south = false;
            west = false;
            playerPresenceCheck = false;
            checkForDoorOpeningStability = false;
            if (northernRoomOpening == true)
            {
                north = true;
            }
            if (easternRoomOpening == true)
            {
                east = true;
            }
            if (southernRoomOpening == true)
            {
                south = true;
            }
            if (westernRoomOpening == true)
            {
                west = true;
            }
            if (playerOccupationRoom == true)
            {
                playerPresenceCheck = true;
            }
            //roomBeenVisted and checkForDoorOPeningStability are ivolved in a checking system if a room has been vsted by the genrator selector before
            if(roomBeenVisited == true){
                checkForDoorOpeningStability = true;
            }
        }
        public string createRoomMapTopSection(string emptyFillerRoom, string wallFillerRoom)
        {
            string roomMap = "";
            if (north == true)
            {
                roomMap += wallFillerRoom+emptyFillerRoom+wallFillerRoom;
            }
            else { roomMap += wallFillerRoom+wallFillerRoom+wallFillerRoom; }
            return roomMap;
        }
        public string createRoomMapMidSection(string emptyFillerRoom , string wallFillerRoom, string playerMarkerRoom)
        {
            string roomMap = "";
            if (west == true)
            {
                roomMap += emptyFillerRoom;
            }
            else { roomMap += wallFillerRoom; }
            if(playerPresenceCheck == true)
            {
                roomMap += playerMarkerRoom;
            }
            else { roomMap += emptyFillerRoom; }
            if (east == true)
            {
                roomMap += emptyFillerRoom;
            }
            else { roomMap += wallFillerRoom; }
            return roomMap;
        }
        public string createRoomMapBotSection(string emptyFillerRoom, string wallFillerRoom)
        {

            string roomMap = "";
            if (south == true)
            {

                roomMap += wallFillerRoom+emptyFillerRoom+wallFillerRoom;
            }
            else { roomMap += wallFillerRoom + wallFillerRoom + wallFillerRoom ; }
            return roomMap;
        }
        public bool isThisRoomAllLocked()
        {
            if (north == false && south == false && east==false && west == false)
            {
                return true;
            }
            return false;
        }
    }
    

}
