import { Crop, Key } from 'react-feather'
export default [
  {
    header: 'Setting'
  },
  {
    id: 'global-setting',
    title: 'Global Setting',
    icon: <Crop size={20} />,
    navLink: '/setting/global-setting'
  },
  {
    id: 'sip-setting',
    title: 'SIP Setting',
    icon: <Key size={20} />,
    navLink: '/setting/sip-setting'
  }
]
