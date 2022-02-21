using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace MirrorLobby {
    public class Player : NetworkBehaviour {

		public static Player localPlayer;

		void Start() {
			if (isLocalPlayer) {
				localPlayer = this;
			}
		}
		public void HostGame() {
            string matchID = MatchMaker.GetRandomMatchID();
            CmdHostGame(matchID);
		}

        [Command]
        void CmdHostGame(string _matchID){
            if(MatchMaker.instance.HostGame(_matchID, gameObject)){
                Debug.Log($"<color = green>Game hosted successfully</color>");
            }
            else {
                Debug.Log($"<color = red>Game hosted failed</color>");
            }

        }

	}

}