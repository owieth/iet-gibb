
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author vmadmin
 */
public class Winkler_Olivier {

    public static void swap(int[] A, int i, int j) {
        int item1 = A[i];
        int item2 = A[j];
        A[i] = item2;
        A[j] = item1;
    }

    public static void selectionSort(int[] A) {
        for (int i = 0; i < A.length; i++) {
            int minJ = i;
            for (int j = i + 1; j < A.length; j++) {
                if(A[j] < A[minJ]){
                    minJ = j;
                }
            }
            if(minJ != i){
                swap(A, i, minJ);
            }
        }
    }

    public static String[] convert(ArrayList<String> list) {
        String[] stringArray = new String[list.size()];
        for (int i = 0; i < list.size(); i++){
            stringArray[i] = list.get(i);
        }
        return stringArray;
    }

    public static int[] readNumbers(String dateiName) {
        int[] zahlen = new int[10];
        try {
            Scanner scanner = new Scanner(new File(dateiName));
            while (scanner.hasNextLine()){
                for (int i = 0; i < zahlen.length; i++){
                    //dateiName.split(",");
                    zahlen[i] = Integer.parseInt(scanner.nextLine());
                   
                }
            }
            
        } catch (Exception e) {
        }

        return zahlen;
    }
    
    static void delay_test(long [] testzeiten){
        testzeiten = new long[] {10, 200, 500};
        for (int i = 0; i < testzeiten.length; i++){
            long start = System.currentTimeMillis();
            delay(testzeiten[i]);
            long end = System.currentTimeMillis();
            long diff = end - start;
            System.out.println("SOLL " + testzeiten[i] +"ms\tIST " + diff +"ms");
        }
    }
    
    public static int binomialkoeffizient(int n, int k){
        if(k == 0){
            return 1;
        } else if((2 * k) > n){
            return binomialkoeffizient(n, n - k);
        } else {
            return (n + 1 - k) / k * binomialkoeffizient(n, k - 1);
        }
    }
    
    private static void delay(long ms){
        try{ 
            Thread.sleep(ms);
        } catch (InterruptedException e){}
    }

    public static void main(String[] args) {
        int[] A = {19, 2, 3, 20};
        selectionSort(A);
        System.out.println(Arrays.toString(A));
        ArrayList<String> list = new ArrayList<>();
        System.out.println("Leer:" + Arrays.toString(convert(list)));
        list.add("Alice");
        System.out.println(Arrays.toString(convert(list)));
        String dateiName = "zahlen.txt";
        System.out.println("Aus Datei:" + Arrays.toString(readNumbers(dateiName)));
        long[] milliseconds = {10,200,500};
        delay_test(milliseconds);
        int binomial = binomialkoeffizient(4,2);
        System.out.println("Koeffizient n=4, k=2: erwarte 6, ist " + binomial);
    }
}
