package at.ghtw.terminverwaltung_app.Data;

/**
 * Created by C. P. Wutti
 */

public class Database {

    private static Database dbInstance = null;

    public static Database getInstance(){
        if(dbInstance==null)
            dbInstance = new Database();
        return dbInstance;
    }

    private Database(){

    }
}

