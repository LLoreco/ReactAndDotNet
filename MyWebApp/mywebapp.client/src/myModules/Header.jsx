import '../myStyles/HeaderStyle.css'

function Header({activeTask, nextTask, timer}){
    return(
        <div className="HeaderBackground">
            {activeTask && (
                <div className='HeaderActiveTask'>
                    {activeTask}
                </div>
            )}
            <div className='NextTask'>{nextTask} {timer}</div>
            <div className='CreateTaskButton'>Добавить задачу МАРКДАУН</div>
        </div>
    );
}

export default Header;