import '../../myStyles/BodyComponents/BodyTable.css';
import ActionButtons from './ActionButtons';

function BodyTable() {
    return (
        <div className="TableWrapper">
            <table className="TaskTable">
                <thead className="TaskTableThead">
                    <tr>
                        <th>ID</th>
                        <th>Название задачи</th>
                        <th>Время</th>
                        <th>Действия</th>
                    </tr>
                </thead>
                <tbody className='TaskTableBody'>
                    <tr>
                        <td>1</td>
                        <td>Открыть задачу МАРКДАУН</td>
                        <td>24.12.2025 13:00</td>
                        <td><ActionButtons /></td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>Пример задачи</td>
                        <td>25.12.2025 16:00</td>
                        <td><ActionButtons /></td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Открыть задачу МАРКДАУН</td>
                        <td>25.12.2025 17:00</td>
                        <td><ActionButtons /></td>
                    </tr>
                    <tr>
                        <td>4</td>
                        <td>Пример задачи</td>
                        <td>30.12.2025 9:00</td>
                        <td><ActionButtons /></td>
                    </tr>
                </tbody>
            </table>
        </div>
    );
}

export default BodyTable;
