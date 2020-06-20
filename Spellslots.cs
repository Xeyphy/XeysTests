using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xeys_DnD_Player
{
    class Spellslots
    {
        [JsonProperty]
        int[] maxSpellSlots;
        [JsonProperty]
        int[] currentSpellSlots;

        public Spellslots()
        {
            maxSpellSlots = new int[9];
            currentSpellSlots = new int[9];
        }
        public void generateCaster(int castertype, int level, bool warlock)
        {
            if (warlock) {generateWarlock(level);return;}
            switch (castertype)
            {
                case 0: generateTQCaster(level);break;
                case 1: generateHalfCaster(level);break;
                case 2: generafeFullCaster(level);break;
                default: generateNoCaster(); break;
            }
        }

        private void generateWarlock(int level)
        {
            switch (level)
            {
                case 1:  fillSpellSlot(1, 1); break;
                case 2:  fillSpellSlot(1, 2); break;
                case 3:  fillSpellSlot(2, 2); break;
                case 4:  fillSpellSlot(2, 2); break;
                case 5:  fillSpellSlot(3, 2); break;
                case 6:  fillSpellSlot(3, 2); break;
                case 7:  fillSpellSlot(4, 2); break;
                case 8:  fillSpellSlot(4, 2); break;
                case 9:  fillSpellSlot(5, 2); break;
                case 10: fillSpellSlot(5, 3); break;
                case 12: fillSpellSlot(5, 3); break;
                case 11: fillSpellSlot(5, 3); break;
                case 13: fillSpellSlot(5, 3); break;
                case 14: fillSpellSlot(5, 3); break;
                case 15: fillSpellSlot(5, 3); break;
                case 16: fillSpellSlot(5, 3); break;
                case 17: fillSpellSlot(5, 4); break;
                case 18: fillSpellSlot(5, 4); break;
                case 19: fillSpellSlot(5, 4); break;
                case 20: fillSpellSlot(5, 4); break;
            }
        }

        private void generafeFullCaster(int level)
        {
            switch (level)
            {
                case 1:  fillSpellSlot(0, 2); break;
                case 2:  fillSpellSlot(0, 3); break;
                case 3:  fillSpellSlot(0, 4); fillSpellSlot(1, 2); break;
                case 4:  fillSpellSlot(0, 4); fillSpellSlot(1, 3); break;
                case 5:  fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 2); break;
                case 6:  fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); break;
                case 7:  fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 1); break;
                case 8:  fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 2); break;
                case 9:  fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 1); break;
                case 10: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 2); break;
                case 11: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 2); fillSpellSlot(5, 1); break;
                case 12: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 2); fillSpellSlot(5, 1); break;
                case 13: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 2); fillSpellSlot(5, 1); fillSpellSlot(6, 1); break;
                case 14: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 2); fillSpellSlot(5, 1); fillSpellSlot(6, 1); break;
                case 15: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 2); fillSpellSlot(5, 1); fillSpellSlot(6, 1); fillSpellSlot(7, 1); break;
                case 16: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 2); fillSpellSlot(5, 1); fillSpellSlot(6, 1); fillSpellSlot(7, 1); break;
                case 17: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 2); fillSpellSlot(5, 1); fillSpellSlot(6, 1); fillSpellSlot(7, 1); fillSpellSlot(8, 1); break;
                case 18: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 3); fillSpellSlot(5, 1); fillSpellSlot(6, 1); fillSpellSlot(7, 1); fillSpellSlot(8, 1); break;
                case 19: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 3); fillSpellSlot(5, 2); fillSpellSlot(6, 1); fillSpellSlot(7, 1); fillSpellSlot(8, 1); break;
                case 20: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 3); fillSpellSlot(5, 2); fillSpellSlot(6, 2); fillSpellSlot(7, 1); fillSpellSlot(8, 1); break;

            }

            refreshSpellSlots();
        }

        private void fillSpellSlot(int v1, int v2)
        {
            this.maxSpellSlots[v1] = v2;
        }

        private void generateHalfCaster(int level)
        {
            switch (level)
            {
                case 1:break;
                case 2: fillSpellSlot(0, 2);break;
                case 3: fillSpellSlot(0, 3); break;
                case 4: fillSpellSlot(0, 3); break;
                case 5: fillSpellSlot(0, 4); fillSpellSlot(1, 2); break;
                case 6: fillSpellSlot(0, 4); fillSpellSlot(1, 2); break;
                case 7: fillSpellSlot(0, 4); fillSpellSlot(1, 3); break;
                case 8: fillSpellSlot(0, 4); fillSpellSlot(1, 3); break;
                case 9: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 2); break;
                case 10: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 2); break;
                case 11: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); break;
                case 12: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); break;
                case 13: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 1); break;
                case 14: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 1); break;
                case 15: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 2); break;
                case 16: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 2); break;
                case 17: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 1); break;
                case 18: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 1); break;
                case 19: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 2); break;
                case 20: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 3); fillSpellSlot(4, 2); break;
            }
        }

        private void generateTQCaster(int level)
        {
            switch (level)
            {
                case 1:break;
                case 2:break;
                case 3: fillSpellSlot(0, 2);break;
                case 4: fillSpellSlot(0, 3);break;
                case 5: fillSpellSlot(0, 3); break;
                case 6: fillSpellSlot(0, 3); break;
                case 7: fillSpellSlot(0, 4); fillSpellSlot(1, 2); break;
                case 8: fillSpellSlot(0, 4); fillSpellSlot(1, 2); break;
                case 9: fillSpellSlot(0, 4); fillSpellSlot(1, 2); break;
                case 10: fillSpellSlot(0, 4); fillSpellSlot(1, 3); break;
                case 11: fillSpellSlot(0, 4); fillSpellSlot(1, 3); break;
                case 12: fillSpellSlot(0, 4); fillSpellSlot(1, 3); break;
                case 13: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 2); break;
                case 14: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 2); break;
                case 15: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 2); break;
                case 16: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); break;
                case 17: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); break;
                case 18: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); break;
                case 19: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 1); break;
                case 20: fillSpellSlot(0, 4); fillSpellSlot(1, 3); fillSpellSlot(2, 3); fillSpellSlot(3, 1); break;
                default:generateNoCaster();break;
            }
        }
        public void refreshSpellSlots()
        {
            maxSpellSlots.CopyTo(currentSpellSlots, 0);
        }

        private void generateNoCaster()
        {
            maxSpellSlots = new int[9];
            currentSpellSlots = new int[9];
        }
    }
}
