package monitor;

import java.awt.*;
import java.util.logging.Level;
import java.util.logging.Logger;

class Graph implements  Runnable {
    private Graphics g;
    private Color cl;
    private String nameFunc;
    private int yPoint;

    Graph(Graphics g, String f, Color cl) {
        yPoint = 0;
        this.g = g;
        nameFunc = f;
        this.cl = cl;
        new Thread(this).start();
    }

    @Override
    public void run() {
        for(int x = 0; x < 1280; x++) {
            try {
                Thread.sleep(10);
            } catch (InterruptedException ex) {
                Logger.getLogger(Graph.class.getName()).log(Level.SEVERE, null, ex);
            }
            if(nameFunc.equalsIgnoreCase("sin")){
                yPoint = yPointSin(x);
            }
            else if (nameFunc.equalsIgnoreCase("cos")){
                yPoint = yPointCos(x);
            }
            else if (nameFunc.equalsIgnoreCase("tan")){
                yPoint = yPointTan(x);
            }
            drawPoint(x, yPoint, cl);
        }
    }

    private void drawPoint(int x, int y, Color col) {
        synchronized (g) {
            g.setColor(col);
            g.fillOval(x, y, 5, 5);
        }
    }
    private int yPointSin(int x) {
        return 350+(int)Math.round(200*Math.sin(x*0.01));
    }

    private int yPointCos(int x) {
        return 350+(int)Math.round(200*Math.cos(x*0.01));
    }
    private int yPointTan(int x){
        return 350+(int)Math.round(100*Math.tan(x*0.01));
    }
}
public class MonitorGraphics extends javax.swing.JFrame {
    private java.awt.Canvas canvas1;

    public MonitorGraphics() {
        initComponents();
    }

    @SuppressWarnings("unchecked")
    private void initComponents() {

        canvas1 = new java.awt.Canvas();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setMinimumSize(new java.awt.Dimension(1280, 720));
        setName("Graphics"); // NOI18N
        setTitle("Graphics");
        setPreferredSize(new java.awt.Dimension(1280, 720));
        setSize(new java.awt.Dimension(0, 0));

        canvas1.setBackground(new java.awt.Color(0, 0, 0));
        canvas1.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyPressed(java.awt.event.KeyEvent evt) {
                canvas1KeyPressed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                        .addComponent(canvas1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );
        layout.setVerticalGroup(
                layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                        .addComponent(canvas1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
        );

        pack();
    }

    private void canvas1KeyPressed(java.awt.event.KeyEvent evt) {
        if (evt.getKeyCode() == evt.VK_SPACE) {
            Graphics g = canvas1.getGraphics();
            g.setColor(Color.WHITE);
            new Graph(g, "sin", Color.BLUE);
            new Graph(g, "cos", Color.GREEN);
            new Graph(g, "tan", Color.RED);
        }
    }

    public static void main(String args[]) {
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new MonitorGraphics().setVisible(true);
            }
        });
    }
}
