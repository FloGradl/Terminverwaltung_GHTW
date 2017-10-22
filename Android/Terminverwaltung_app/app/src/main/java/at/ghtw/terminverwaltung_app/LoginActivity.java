package at.ghtw.terminverwaltung_app;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class LoginActivity extends AppCompatActivity {

    private Button btnLogin;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        initOtherComponents();
    }

    private void initOtherComponents(){
        btnLogin = (Button) findViewById(R.id.btnLogin);
        btnLogin.setOnClickListener(btnLoginListener);
    }

    View.OnClickListener btnLoginListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Intent intent = new Intent(v.getContext(), MeetingActivity.class);
            startActivity(intent);
        }
    };
}
