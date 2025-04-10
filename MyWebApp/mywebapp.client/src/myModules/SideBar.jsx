import '../myStyles/SideBarStyle.css'
import SideBarColumn from './SideBarColumn';
import Logo from './Logo';

function SideBar(){
    return(
        <div className="SideBarBackground">
            <Logo />
            <SideBarColumn iconSize={35}/>
        </div>
    )
}

export default SideBar;