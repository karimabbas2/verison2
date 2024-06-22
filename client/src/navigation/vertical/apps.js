import { Mail, MessageSquare, CheckSquare, Calendar, FileText, Circle, ShoppingCart, User, PlayCircle, Phone, PhoneIncoming } from 'react-feather'

export default [
  {
    header: 'Extensions & Trunks'
  },
  {
    id: 'extenison',
    title: 'Extenison',
    icon: <PlayCircle size={20} />,
    navLink: '/extenison'
  },
  {
    id: 'trunk',
    title: 'Trunk',
    icon: <Phone size={20} />,
    navLink: '/trunk'
  },
  {
    id: 'voice-prompts',
    title: 'Voice Prompts',
    icon: <PhoneIncoming size={20} />,
    navLink: '/voice-prompts'
  }
]
