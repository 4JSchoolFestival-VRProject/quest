using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    public class Status
    {
        public struct Parameters
        {
            public int level;
            public int exp;
            public int hp;
            public int mp;
            public int atk;
            public int def;

            public Parameters(int level, int exp, int hp, int mp, int atk, int def)
            {
                this.level = level;
                this.exp = exp;
                this.hp = hp;
                this.mp = mp;
                this.atk = atk;
                this.def = def;
            }

            public Parameters(Parameters parameters)
            {
                this.level = parameters.level;
                this.exp = parameters.exp;
                this.hp = parameters.hp;
                this.mp = parameters.mp;
                this.atk = parameters.atk;
                this.def = parameters.def;
            }
        }

        private float m_Talent;
        public int levelUpNorm { get { return (int)(m_Parameters.level * (1 + m_Talent) * 5); } }

        private Parameters m_BaseParameters;
        private Parameters m_MaxParameters;
        private Parameters m_Parameters;

        public Parameters maxParameters { get { return m_MaxParameters; } }
        public Parameters parameters { get { return m_Parameters; } }

        public Status(int level, int exp, int hp, int mp, int atk, int def, float talent)
        {
            m_Talent = talent;
            m_BaseParameters = new Parameters(level, exp, hp, mp, atk, def);
            m_MaxParameters = CalcParameters(m_BaseParameters, m_BaseParameters.level, m_Talent);
            m_Parameters = new Parameters(m_MaxParameters);
        }

        public Status(int hp, int mp, int atk, int def, float talent) : this(1, 0, hp, mp, atk, def, talent) { }

        public Status() : this(10, 6, 5, 5, 0.2f) { }

        public void AddDamage(int damage)
        {
            m_Parameters.hp -= damage;
            if (m_Parameters.hp < 0) m_Parameters.hp = 0;
        }

        public void AddExp(int exp)
        {
            m_Parameters.exp += exp;
            CheckAddLevel();
        }

        public void CheckAddLevel()
        {
            if (m_Parameters.exp < levelUpNorm) return;
            m_Parameters.exp -= levelUpNorm;
            m_Parameters.level++;

            Parameters oldMax = new Parameters(m_MaxParameters);
            m_MaxParameters = CalcParameters(m_BaseParameters, m_Parameters.level, m_Talent);

            if (m_Parameters.hp < m_MaxParameters.hp)
            {
                m_Parameters.hp += m_MaxParameters.hp - oldMax.hp;
                if (m_Parameters.hp > m_MaxParameters.hp) m_Parameters.hp = m_MaxParameters.hp;
            }
            if (m_Parameters.mp < m_MaxParameters.mp)
            {
                m_Parameters.mp += m_MaxParameters.mp - oldMax.mp;
                if (m_Parameters.mp > m_MaxParameters.mp) m_Parameters.mp = m_MaxParameters.mp;
            }

            m_Parameters.atk = m_MaxParameters.atk;
            m_Parameters.def = m_MaxParameters.def;
        }

        public static int CalcParameter(int parameta, int level, float talent)
        {
            return parameta + (int)((level - 1) * talent * parameta);
        }

        public static Parameters CalcParameters(Parameters baseParameters, int level, float talent)
        {
            Parameters p = new Parameters(baseParameters);

            p.level = level;
            p.hp = CalcParameter(p.hp, level, talent);
            p.mp = CalcParameter(p.mp, level, talent);
            p.atk = CalcParameter(p.atk, level, talent);
            p.def = CalcParameter(p.def, level, talent);
            return p;
        }
    }
}