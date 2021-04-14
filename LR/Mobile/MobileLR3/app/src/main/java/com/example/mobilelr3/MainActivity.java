package com.example.mobilelr3;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    ArrayList<State> states = new ArrayList<State>();
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setInitialData();
        RecyclerView recyclerView = (RecyclerView) findViewById(R.id.list);
        Intent intent = new Intent(this, About.class);
        StateAdapter.OnStateClickListener stateClickListener = new StateAdapter.OnStateClickListener() {
            @Override
            public void onStateClick(State state, int position) {
                intent.putExtra("message", state.getName());
                startActivity(intent);
            }
        };
        StateAdapter adapter = new StateAdapter(this, states, stateClickListener);
        recyclerView.setAdapter(adapter);
    }
    private void setInitialData(){
        states.add(new State ("Россия", "Москва", R.drawable.russia));
        states.add(new State ("Аргентина", "Буэнос-Айрес", R.drawable.argentina));
        states.add(new State ("Германия", "Берлин", R.drawable.germany));
        states.add(new State ("Чехия", "Прага", R.drawable.czech));
        states.add(new State ("Норвегия", "Осло", R.drawable.norway));
    }
}