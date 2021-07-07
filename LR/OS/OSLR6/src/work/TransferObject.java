package work;

import java.io.*;
import java.util.Random;

public class TransferObject implements Serializable{
    private int[][] mas;
    private static Random random = new Random();
    public TransferObject() {
        mas = new int[2][2];
        for (int i = 0; i < mas.length; i++) {
            for (int j = 0; j < mas.length; j++) {
                mas[i][j] = random.nextInt(20);
            }
        }
    }
    public int[][] getMassive(){
        return mas;
    }
}
