import '../myStyles/SideBarContent.css'

function SideBarColumn({iconSize}){
    return(
        <>
            <div className = "SideBarContent">
                <img src="src/assets/user.svg" alt="User" width={iconSize} height={iconSize} />
            </div>
            <div className = "SideBarContent">
                <img src='src/assets/list.svg' alt='Tasks' width={iconSize} height={iconSize}/>
            </div>
            <div className = "SideBarContent">
                <img src='src/assets/interrogation.svg' alt='Tasks' width={iconSize} height={iconSize}/>
            </div>
        </>
    );
}

export default SideBarColumn;