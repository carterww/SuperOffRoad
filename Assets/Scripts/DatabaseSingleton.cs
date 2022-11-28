using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

public class DatabaseSingleton : MonoBehaviour
{
    private static IDbConnection conn;
    private static string[] tables = {
        "Highscores (initials CHAR(3) PRIMARY KEY, time INTEGER)"
    };

    // Start is called before the first frame update
    void Awake()
    {
        string uri = "URI=file:" + Application.persistentDataPath + "/db.sqlite";
        conn = new SqliteConnection(uri);
        conn.Open();

        for (int t = 0; t < 1; t++) {
            IDbCommand createTableComm = conn.CreateCommand();
            createTableComm.CommandText = "CREATE TABLE IF NOT EXISTS " + tables[t];
            createTableComm.ExecuteReader();
        }
    }

    void OnDestroy()
    {
        conn.Close();
    }

    public void Highscore(string initials, int time) {
        IDbCommand newScoreComm = conn.CreateCommand();
        newScoreComm.CommandText = "INSERT OR REPLACE INTO Highscores (initials, time) VALUES ('" + initials + "', '" + time + "')"; 
        newScoreComm.ExecuteNonQuery();
    }
}
