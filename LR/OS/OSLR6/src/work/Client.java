package work;

import java.io.*;
import java.net.Socket;

public class Client {
    private static double detA;

    public Client() {
    }
    static double det(int A[][]){
        int n = A.length;
        if(n == 1) return A[0][0];
        double ans = 0;
        int B[][] = new int[n-1][n-1];
        int l = 1;
        for(int i = 0; i < n; ++i){
            int x = 0, y = 0;
            for(int j = 1; j < n; ++j){
                for(int k = 0; k < n; ++k){
                    if(i == k) continue;
                    B[x][y] = A[j][k];
                    ++y;
                    if(y == n - 1){
                        y = 0;
                        ++x;
                    }
                }
            }
            ans += l * A[0][i] * det(B);
            l *= (-1);
        }
        return ans;
    }
    public static void main(String[] args) {
        try {
            TransferObject object = new TransferObject();
            Socket s = new Socket("localhost", 6001);
            InputStream is = s.getInputStream();
            OutputStream os = s.getOutputStream();
            ObjectOutputStream oos = new ObjectOutputStream(os);
            oos.writeObject(object);
            oos.flush();
            // oos.close();
            ObjectInputStream ois = new ObjectInputStream(is);
            object = (TransferObject) ois.readObject();
            int[][] recivedMas = object.getMassive();
            for (int i = 0; i < recivedMas.length; i++) {
                for (int j = 0; j < recivedMas.length; j++) {
                    int i1 = recivedMas[i][j];
                    System.out.println("[" + i + "][ " + j + "] " + i1);
                }
            }
            oos.writeObject(det(recivedMas));

        } catch (IOException e) {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        } catch (ClassNotFoundException e) {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        }
    }
}
