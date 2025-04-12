import '../myStyles/HeaderStyle.css'
import NextTask from './HeaderComponents/NextTask';
import CreateTaskButton from './HeaderComponents/CreateTaskButton';

function Header({activeTask, nextTask, timer}){
    return(
        <div className="HeaderBackground">
            {activeTask && (
                <div className='HeaderActiveTask'>
                    {activeTask}
                </div>
            )}
            <NextTask nextTask={nextTask} timer={timer}/>
            <CreateTaskButton />
        </div>
    );
}

export default Header;