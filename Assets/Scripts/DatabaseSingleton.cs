using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

public class DatabaseSingleton : MonoBehaviour
{
    private static IDbConnection conn;
    private static string[] tables = {
        "Account (username CHAR(16) PRIMARY KEY, password CHAR(32))",
        "Highscore (initials CHAR(3) PRIMARY KEY, time INTEGER)",
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
        newScoreComm.CommandText = "INSERT OR REPLACE INTO Highscore (initials, time) VALUES ('" + initials + "', '" + time + "')"; 
        newScoreComm.ExecuteNonQuery();
    }

    public bool CheckUsername(string username) {
        IDbCommand readUsernamesComm = conn.CreateCommand();
        readUsernamesComm.CommandText = "SELECT * FROM Account;";
        IDataReader dataReader = readUsernamesComm.ExecuteReader();
        while (dataReader.Read()) if (username.Equals(dataReader.GetString(0))) return false;
        return true;
    }

    public void CreateUser(string username, string password) {
        Hash128 hash = new Hash128();
        hash.Append(password);
        IDbCommand newScoreComm = conn.CreateCommand();
        newScoreComm.CommandText = "INSERT OR REPLACE INTO Account (username, password) VALUES ('" + username + "', '" + hash.ToString() + "')"; 
        if (newScoreComm.ExecuteNonQuery() != 1) Debug.Log("There was an unexpected error in CreateUser.");
    }

    public bool LoginUser(string username, string password) {
        Hash128 hash = new Hash128();
        hash.Append(password);
        IDbCommand readUsernamesComm = conn.CreateCommand();
        readUsernamesComm.CommandText = "SELECT * FROM Account;";
        IDataReader dataReader = readUsernamesComm.ExecuteReader();
        while (dataReader.Read()) {
            if (username.Equals(dataReader.GetString(0)) && hash.ToString().Equals(dataReader.GetString(1))) {
                return true;
            }
        }
        return false;
    }
}
