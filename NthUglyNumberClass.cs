public class Solution {
    // TC => O(n)
    // SC => O(n)
    public int NthUglyNumber(int n) {
         if(n == 1){
            return n;
        }

        int p2 = 0, p3 = 0, p5 = 0;
        int n2 = 2, n3 = 3, n5 = 5;

        int[] result = new int[n];
        result[0] = 1;

        for(int i = 1; i < n; i++){
            result[i] = Math.Min(n2, Math.Min(n3, n5));
            if(result[i] == n2){
                p2++;
                n2 = result[p2] * 2;
            }
            if(result[i] == n3){
                p3++;
                n3 = result[p3] * 3;
            }
            if(result[i] == n5){
                p5++;
                n5 = result[p5] * 5;
            }
        }
        return result[n-1];
    }

    // TC => O(nlogk)
    // SC => O(n)
    public int NthUglyNumber1(int n) {
        if(n == 1){
            return n;
        }
        PriorityQueue<long, long> queue = new PriorityQueue<long, long>();
        HashSet<long> hashset = new HashSet<long>();
        int[] primes = [2,3,5];
        queue.Enqueue(1,1);
        hashset.Add(1);
        int count = 1;
        long current = 0;
        for(int i = 1; i<= n ; i++){
            current = queue.Dequeue();
            count++;
            foreach(var num in primes){
                long newNumber = num * current;
                if(!hashset.Contains(newNumber)){
                    queue.Enqueue(newNumber, newNumber);
                    hashset.Add(newNumber);
                }
            }
        }
        return (int)current;
    }
}