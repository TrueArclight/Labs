package lr.one;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

public class Message extends AppCompatActivity {
    private TextView textView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_message);
        textView = findViewById(R.id.messageText);
        Intent intent = getIntent();
        String message = intent.getStringExtra("message");
        if(message.equalsIgnoreCase("c++")){
            message += "\n// Your First C++ Program\n" +
                    "\n" +
                    "#include <iostream>\n" +
                    "\n" +
                    "int main() {\n" +
                    "    std::cout << \"Hello World!\";\n" +
                    "    return 0;\n" +
                    "}";
        }
        if(message.equalsIgnoreCase("java")){
            message += "\n// Your First Java Program\n" +
                    "\n" +
                    "class HelloWorld {\n" +
                    "    public static void main(String[] args) {\n" +
                    "        System.out.println(\"Hello, World!\"); \n" +
                    "    }\n" +
                    "}";
        }
        if(message.equalsIgnoreCase("python")){
            message += "\n// Your First Python Program\n" +
                    "\n" +
                    "print(\"Hello World!\")\n";
        }
        if(message.equalsIgnoreCase("c#")){
            message +="\n// Your First C# Program\n" +
                    "namespace HelloWorld\n" +
                    "{\n" +
                    "    class Hello {         \n" +
                    "        static void Main(string[] args)\n" +
                    "        {\n" +
                    "            System.Console.WriteLine(\"Hello World!\");\n" +
                    "        }\n" +
                    "    }\n" +
                    "}";
        }
        textView.setText(message);
    }
}