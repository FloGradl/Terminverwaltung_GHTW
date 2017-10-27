package at.ghtw.terminverwaltung_app;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuInflater;

public class MeetingActivity extends AppCompatActivity {

    Toolbar tbMenu;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_meeting);

        tbMenu = (Toolbar) findViewById(R.id.tbMenu);
        setSupportActionBar(tbMenu);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu){
        MenuInflater mMenuInflater = getMenuInflater();
        mMenuInflater.inflate(R.menu.menu_meeting_activity, menu);
        return true;
    }



}
