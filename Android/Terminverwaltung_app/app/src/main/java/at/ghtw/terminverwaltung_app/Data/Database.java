package at.ghtw.terminverwaltung_app.Data;

import java.util.ArrayList;

/**
 * Created by C. P. Wutti
 */

public class Database {

    private static Database dbInstance = null;

    private ArrayList<Meeting> meetings;

    public static Database getInstance(){
        if(dbInstance==null)
            dbInstance = new Database();
        return dbInstance;
    }

    private Database(){
        meetings = new ArrayList<>();
    }

    public void addMeeting(Meeting m){
        meetings.add(m);
    }

    public ArrayList<Meeting> getMeetings(){
        return meetings;
    }
}

