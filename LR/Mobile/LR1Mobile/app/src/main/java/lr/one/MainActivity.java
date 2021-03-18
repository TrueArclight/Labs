package lr.one;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    private TextView plList;
    private String message;
    private CheckBox checkBox1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        plList = findViewById(R.id.textView_lang);
        checkBox1 = findViewById(R.id.checkbox1);
        String[] names = {"Java", "Python", "C#", "C++"};
        plList.setText("");
        for (String name : names) {
            plList.append(name + '\n');
        }
    }
    public void sendMessage(View view) {
        Intent intent = new Intent(this, Message.class);
        EditText editText = (EditText) findViewById(R.id.editText);
        message = editText.getText().toString();
        if(checkBox1.isChecked()) {
            intent.putExtra("message", message);
            startActivity(intent);
        }
        else if (!checkBox1.isChecked()){
            Context context = this.getApplicationContext();
            Toast t =Toast.makeText(context, message, Toast.LENGTH_LONG);
            t.show();
        }

    }

    public void moveToAnother(View view) {
        Intent intent = new Intent(this, ColorsToggle.class);
        startActivity(intent);
    }
}