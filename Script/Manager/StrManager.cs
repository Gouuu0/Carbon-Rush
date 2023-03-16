using Godot;
using System;
using System.Collections.Generic;

//Author : Merfoud Kélyan

namespace Com.IsartDigital.Manager
{

    public class StrManager
    {
        //Direction
        public const string RIGHT = "Right";
        public const string LEFT = "Left";
        public const string UP = "Up";
        public const string DOWN = "Down";

        //Other input
        public const string SPECIAL = "Special";

        //GODOT SIGNAL

        //Area2D
        public const string AREA_ENTERED = "area_entered";
        public const string AREA_EXITED = "area_exited";
        public const string AREA_SHAPE_EXITED = "area_shape_exited";
        public const string AREA_SHAPE_ENTERED = "area_shape_entered";

        public const string BODY_ENTERED = "body_entered";
        public const string BODY_EXITED = "body_exited";
        public const string BODY_SHAPE_ENTERED = "body_shape_entered";
        public const string BODY_SHAPE_EXITED = "body_shape_exited";

        //Collision Object
        public const string INPUT_EVENT = "input_event";
        public const string MOUSE_ENTERED = "mouse_entered";
        public const string MOUSE_EXITED = "mouse_exited";

        //Canvas Item
        public const string DRAW = "draw";
        public const string HIDE = "hide";
        public const string ITEM_RECT_CHANGED = "item_rect_changed";
        public const string VISIBILITY_CHANGED = "visibility_changed";

        //Node
        public const string CHILD_ENTERED_TREE = "child_entered_tree";
        public const string CHILD_EXITED_TREE = "child_exited_tree";
        public const string TREE_ENTERED = "tree_entered";
        public const string TREE_EXITED = "tree_exited";
        public const string TREE_EXITING = "tree_exiting";

        public const string READY = "ready";
        public const string RENAMED = "renamed";

        //Object
        public const string SCRIPT_CHANGED = "script_changed";

        //Timer
        public const string TIMEOUT = "timeout";

        //Button
        public const string BUTTON_DOWN = "button_down";
        public const string BUTTON_UP = "button_up";
        public const string PRESSED = "pressed";
        public const string TOGGLED = "toggled"; //renvoie un bool

        //Control
        public const string FOCUS_ENTERED = "focus_entered";
        public const string FOCUS_EXITED = "focus_exited";
        public const string GUI_INPUT = "gui_input";
        public const string MINIMUM_SIZE_CHANGED = "minimum_size_changed";
        public const string MODAL_CLOSED = "modal_closed";
        public const string RESIZED = "resized";
        public const string SIZE_FLAGS_CHANGED = "size_flags_changed";

        //ScrollBar
        public const string SCROLLING = "scrolling";

        //Range
        public const string CHANGED = "changed";
        public const string VALUE_CHANGED = "value_changed";

        //AnimatedSprite
        public const string ANIMATION_FINISHED = "animation_finished";
        public const string FRAME_CHANGED = "frame_changed";

        //Sprite
        public const string TEXTURE_CHANGED = "texture_changed";

        //AudioStreamPlayer
        public const string FINISHED = "finished";

        //Tween
        public const string TWEEN_ALL_COMPLETED = "tween_all_completed";
        public const string TWEEN_COMPLETED = "tween_completed";
        public const string TWEEN_STARTED = "tween_started";
        public const string TWEEN_STEP = "tween_step";

        //Viewport
        public const string GUI_FOCUS_CHANGED = "gui_focus_changed";
        public const string SIZE_CHANGED = "size_changed";

        public const string PLAYER = "Player";
        public const string ENTITIES_HITBOX_PATH = "HitBox";

        //CallDeffered String
        public const string ADDCHILD = "add_child";
        public const string REMOVE_CHILD = "remove_child";

        public const string GLOBAL_POSITION = "global_position";
        public const string POSITION = "position";
        public const string SET = "set";

        //I don't remember why this is here
        public const string SELF_MODULATE = "self_modulate";

        //Might be useful
        public const string ACTIVATOR = "Activator";

        public const string PLAY = "Play";
        public const string QUIT = "Quit";
        public const string CREDIT = "Credit";
        public const string PARAMETERS = "Parameter";

        public const string GAME_OVER = "GAME_OVER";
        public const string PAUSE = "PAUSE";
        public const string CONTINUE = "CONTINUE";
        public const string MENU = "MENU";
        public const string RETRY = "RETRY";

        public const string SFX_EVENT_FINISHED = "finished";

        public const string WIN = "WIN";
        public const string FACT = "FACT";
        public const string KNOW = "KNOW";

        //List of translation
        static public List<string> playList = new List<string>() {"Play","Jouer"};
        static public List<string> parameterList = new List<string>() {"Parameters", "Paramètres" };
        static public List<string> creditList = new List<string>() {"Credit","Crédit"};
        static public List<string> quitList = new List<string>() {"Quit","Quitter"};

        //Music Keys for the dictionary
        public const string AMBIANCE = "AMBIANCE";
        public const string MUSIC = "MUSIC";

        //Sfx Keys for the dictionarry
        public const string CAR_KEYS = "CAR_KEYS";
        public const string DOOR_CLOSE = "DOOR_CLOSE";
        public const string DOOR_OPEN = "DOOR_OPEN";
        public const string FAMILY_FOOTSTEP_A = "FAMILY_FOOTSTEP_A";
        public const string FAMILY_FOOTSTEP_B = "FAMILY_FOOTSTEP_B";
        public const string FAMILY_FOOTSTEP_C = "FAMILY_FOOTSTEP_C";
        public const string FAMILY_FOOTSTEP_D = "FAMILY_FOOTSTEP_D";
        public const string FAUCET_OPEN = "FAUCET_OPEN";
        public const string FAUCET_CLOSE = "FAUCET_CLOSE";
        public const string FRIDGE_OPEN = "FRIDGE_OPEN";
        public const string FRIDGE_CLOSE = "FRIDGE_CLOSE";
        public const string HEATER_OFF = "HEATER_OFF";
        public const string HEATER_ON = "HEATER_ON";
        public const string LIGHT_OFF = "LIGHT_OFF";
        public const string LIGHT_ON = "LIGHT_ON";
        public const string MENU_CLICK = "MENU_CLICK";
        public const string O2_ALMOST_FULL = "O2_ALMOST_FULL";
        public const string PLAYER_SPOTTED = "PLAYER_SPOTTED";
        public const string TV_STATIC = "TV_STATIC";
        public const string TV_OFF = "TV_OFF";
        public const string WINDOW_CLOSE = "WINDOW_CLOSE";
        public const string WINDOW_OPEN = "WINDOW_OPEN";
    }
}