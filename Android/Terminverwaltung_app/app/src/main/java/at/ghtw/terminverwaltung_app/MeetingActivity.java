package at.ghtw.terminverwaltung_app;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuInflater;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import java.util.ArrayList;

import at.ghtw.terminverwaltung_app.Data.Database;
import at.ghtw.terminverwaltung_app.Data.Meeting;

public class MeetingActivity extends AppCompatActivity {

    private Toolbar tbMenu;
    private ListView lvMeetings;
    private Database db;
    private ArrayList<Meeting> helpMeetings;
    ArrayAdapter<Meeting> meetingAdapter;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_meeting);
        loadComponents();
        loadMeetingsAndFill();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu){
        MenuInflater mMenuInflater = getMenuInflater();
        mMenuInflater.inflate(R.menu.menu_meeting_activity, menu);
        return true;
    }

    private void loadComponents(){
        db = Database.getInstance();

        tbMenu = (Toolbar) findViewById(R.id.tbMenu);
        setSupportActionBar(tbMenu);

        lvMeetings =  (ListView) findViewById(R.id.lvMeetings);
        helpMeetings = new ArrayList<>();

        meetingAdapter = new ArrayAdapter<Meeting>(this, android.R.layout.simple_list_item_1, helpMeetings);
        lvMeetings.setAdapter(meetingAdapter);
    }

    private void loadMeetingsAndFill(){
        ArrayList<Meeting> helpMeetings2 = db.getMeetings();
        for(int i = 0; i < helpMeetings2.size(); i++)
            helpMeetings.add(helpMeetings2.get(i));
        meetingAdapter.notifyDataSetChanged();
    }
}
