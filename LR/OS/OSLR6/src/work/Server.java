package work;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {
    public Server() {
    }
    public static void main(String[] args) {
        try {
            ServerSocket serverSocket = new ServerSocket(6001);
            Socket s = serverSocket.accept();
            InputStream is = s.getInputStream();
            OutputStream os = s.getOutputStream();
            ObjectInputStream ois = new ObjectInputStream(is);
            ObjectOutputStream oos = new ObjectOutputStream(os);
            TransferObject object = (TransferObject) ois.readObject();

            int[][] recivedMas = object.getMassive();

            for (int i = 0; i < recivedMas.length; i++) {
                for (int j = 0; j < recivedMas.length; j++) {
                    int i1 = recivedMas[i][j];
                    System.out.println("[" + i + "][" + j + "] " + i1);
                }
            }
            oos.writeObject(object);
            oos.flush();
            System.out.println("Определитель матрицы равен: " + ois.readObject());
        } catch (
                IOException e) {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        } catch (ClassNotFoundException e) {
            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
        }
    }
}
