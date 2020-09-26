import java.util.ArrayList;
 /**
    This program demonstrates the permutation generator.
 */
 public class PermutationGeneratorDemo
 {
    public static void main(String[] args)
    {
      PermutationGenerator generator = new PermutationGenerator(args[0]);
      ArrayList<String> permutations = generator.getPermutations();
      for (String s : permutations)
      {
           System.out.println(s);
      }
   }
}