using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace npuzzle
{
    public class node
    {

        public int Total_F;//cost
        public static int N = Program.N;
        public List<node> Node = new List<node>();//list for children of each node
        public node parent;
        public int[] puzzle = new int[N * N];
        int blank_tile;
        public int level;
        public int hammingdistance ;
        public int manhattanDistance;                       
        public node(int[] p,int lev)
        {
            set_puzzle(p);
            hammingdistance = Program.hammingdistance(puzzle);
            manhattanDistance = Program.manhattancost(puzzle);
            level = lev;
        }
        public void set_puzzle(int[] p)
        {
            for (int i = 0; i < puzzle.Length; i++)
            {
                this.puzzle[i] = p[i];
            }
        }
        public void nextmove(node n)
        {
            for (int i = 0; i < puzzle.Length; i++)
            {
                if (puzzle[i] == 0)
                    blank_tile = i;
            }
            if (blank_tile % N < N - 1)
            {
                moveright(puzzle, blank_tile, n);

            }
            if (blank_tile % N > 0)
            {
                moveleft(puzzle, blank_tile, n);
            }
            if (blank_tile - N >= 0)
            {
                moveup(puzzle, blank_tile, n);

            }
            if (blank_tile + N < puzzle.Length)
            {
                movedown(puzzle, blank_tile, n);
            }           
        }
        public void moveright(int[] p, int i, node n)
        {
                int newlevel;
                newlevel = n.level + 1;
                int[] newp = new int[N*N];
                copypuzzle(newp, p);
                int temp = newp[i + 1];
                newp[i + 1] = newp[i];
                newp[i] = temp;//for changing the numbers
                node newnode = new node(newp,newlevel);
                newnode.parent = n;//to set a child to the parent

            if (n.parent != null && issamepuzzle(newnode.puzzle, n.parent.puzzle))//for check that child does not equal the grandparent
            {
                return;
            }
           newnode.Total_F=level+newnode.manhattanDistance;
            //newnode.Total_F = level + newnode.hammingdistance;
            Node.Add(newnode);  
        }
        public void moveleft(int[] p, int i, node n)
        {

                int newlevel;
                newlevel = n.level + 1;
                 int[] newp = new int[N*N];
                copypuzzle(newp, p);
                int temp = newp[i - 1];
                newp[i - 1] = newp[i];
                newp[i] = temp;
                node newnode = new node(newp,newlevel);
                newnode.parent = n;
                if (n.parent != null && issamepuzzle(newnode.puzzle, n.parent.puzzle))
                {
                    return;
                }

            newnode.Total_F = level + newnode.manhattanDistance;
            //newnode.Total_F = level + newnode.hammingdistance;
            Node.Add(newnode);
          

        }
        public void moveup(int[] p, int i, node n)
        {

            int newlevel;
            newlevel = n.level + 1;
            int[] newp = new int[N*N];
                copypuzzle(newp, p);
                int temp = newp[i - N];
                newp[i - N] = newp[i];
                newp[i] = temp;
                node newnode = new node(newp,newlevel);
                newnode.parent = n;
            if (n.parent != null && issamepuzzle(newnode.puzzle, n.parent.puzzle))
            {
                return;
            }
            newnode.Total_F = level + newnode.manhattanDistance;
            //newnode.Total_F = level + newnode.hammingdistance;
            Node.Add(newnode);

        }
        public void movedown(int[] p, int i, node n)
        {
            int newlevel;
            newlevel = n.level + 1;
            int[] newp = new int[N*N];
                copypuzzle(newp, p);
                int temp = newp[i + N];
                newp[i + N] = newp[i];
                newp[i] = temp;
                node newnode = new node(newp, newlevel);
                newnode.parent = n;
                if (n.parent != null && issamepuzzle(newnode.puzzle, n.parent.puzzle))
                {
                    return;
                }            
             newnode.Total_F = level + newnode.manhattanDistance;
             //newnode.Total_F = level + newnode.hammingdistance;
            Node.Add(newnode);    
           
        }
        public bool issamepuzzle(int[] p,int [] p2)
        {
            bool flag = true;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] != p2[i])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public void copypuzzle(int[] a, int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                a[i] = b[i];
            }
        }
    }
}
