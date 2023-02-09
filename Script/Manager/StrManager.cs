using Godot;
using System;

namespace Com.IsartDigital.Manager {

    public readonly struct StrManager
    {
        //Direction
        public const string RIGHT = "Right";
        public const string LEFT = "Left";
        public const string UP = "Up";
        public const string DOWN = "Down";

        //Other input
        public const string GOD_MOD = "GodMod";
        public const string SPECIAL = "Special";

        //Godot signal
        public const string AREA_ENTERED = "area_entered";
        public const string AREA_EXITED = "area_exited";

        public const string TIMEOUT = "timeout";

        public const string BODY_ENTERED = "body_entered";
        public const string BODY_EXITED = "body_exited";

        public const string PRESSED = "pressed";
        // pArea.Name
        public const string FLOOR = "Floor";
        public const string WALL_RIGHT = "WallRight";
        public const string WALL_LEFT = "WallLeft";
        public const string CEILING = "Ceiling";

        public const string PLAYER = "Player";

        //CallDeffered String
        public const string ADDCHILD = "add_child";
        public const string REMOVE_CHILD = "remove_child";

        public const string GLOBAL_POSITION = "global_position";
        public const string POSITION = "position";
        public const string SET = "set";

        //I don't remember why this is here
        public const string BTN_PROP_SELF_MODULATE = "self_modulate";

        //Might be useful (press x to doubt)xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        public const string ACTIVATOR = "Activator";

        public const string PLAY = "PLAY";
        public const string QUIT = "QUIT";
        public const string CREDIT = "CREDIT";
        public const string PARAMETERS = "PARAMETERS";

        public const string GAME_OVER = "GAME_OVER";
        public const string PAUSE = "PAUSE";
        public const string CONTINUE = "CONTINUE";
        public const string MENU = "MENU";
        public const string RETRY = "RETRY";

        public const string SFX_EVENT_FINISHED = "finished";

        public const string WIN = "WIN";
        public const string FACT = "FACT";
        public const string KNOW = "KNOW";
    }
    //where is the cake?
}