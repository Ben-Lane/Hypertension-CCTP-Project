using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum profiles 
{ 
    maleAdult, 
    femaleAdult, 
    maleChild, 
    femaleChild 
};

public class PlayerProfiles
{
    private UserProfileData selectedProfile;
   
    public UserProfileData SelectProfile(int profile)
    {
        selectedProfile = new UserProfileData();

        int usedProfile = profile;

        switch(usedProfile)
        {
            //Generate a male adult player profile
            case (int)profiles.maleAdult:

                selectedProfile.age = 20;
                selectedProfile.height = 70;
                selectedProfile.weight = 85;
                selectedProfile.daily_steps = new float[14] {4000f, 4000f, 2000f, 4000f, 4000f, 4000f, 4000f,
                                                            4000f, 4000f, 2000f, 4000f, 4000f, 4000f, 4000f };
                break;

            //Generate a female adult player profile
            case (int)profiles.femaleAdult:

                selectedProfile.age = 20;
                selectedProfile.height = 64;
                selectedProfile.weight = 77;
                selectedProfile.daily_steps = new float[14] {3000f, 3000f, 3000f, 3000f, 3000f, 3000f, 3000f,
                                                            3000f, 3000f, 3000f, 3000f, 3000f, 3000f, 3000f };
                break;

            //Generate a male child player profile
            case (int)profiles.maleChild:

                selectedProfile.age = 11;
                selectedProfile.height = 56;
                selectedProfile.weight = 35;
                selectedProfile.daily_steps = new float[14] {2000f, 2000f, 2000f, 2000f, 2000f, 2000f, 2000f,
                                                            2000f, 2000f, 2000f, 2000f, 2000f, 2000f, 2000f };
                break;

            //Generate a female child player profile
            case (int)profiles.femaleChild:

                selectedProfile.age = 11;
                selectedProfile.height = 57;
                selectedProfile.weight = 38;
                selectedProfile.daily_steps = new float[14] {1000f, 1000f, 1000f, 1000f, 1000f, 1000f, 1000f,
                                                            1000f, 1000f, 1000f, 1000f, 1000f, 1000f, 1000f };
                break;

        }

        return selectedProfile;
    }
}
