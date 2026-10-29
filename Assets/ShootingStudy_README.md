# 간단한 총알 발사 스터디

`Assets/Scenes/ShootingStudy.unity`를 열고 Play를 누른 다음 Game 화면을 클릭하세요.

- WASD 또는 방향키: 현재 바라보는 방향 기준으로 앞뒤, 좌우 이동
- Space: 누를 때마다 총알 한 발 발사
- 주황색 상자: 총알이 맞으면 물리 힘으로 밀리는 연습용 표적
- 다시 시작: Play를 껐다 켜면 원래 위치로 돌아옵니다.

## 공부할 코드 두 개

1. `Scripts/Player/PlayerController.cs`
   - `Keyboard.current`: 현재 프로젝트에 설정된 Input System으로 키 입력 읽기
   - `transform.position += (transform.rotation * 방향) * 속도 * Time.deltaTime`: 위치에 직접 값을 더해서 이동
   - `move.normalized`: 대각선으로 움직일 때도 같은 속도 유지
   - `transform.rotation * move.normalized`: 현재 회전을 이동 방향에 적용
   - `Instantiate`: FirePoint 위치와 방향으로 총알 프리팹 복제
2. `Scripts/Combat/Bullet.cs`
   - `GetComponent<Rigidbody>()`: 총알의 물리 컴포넌트 가져오기
   - `AddForce(..., ForceMode.VelocityChange)`: 생성될 때 앞쪽으로 속도를 한 번 더하기
   - `Destroy`: 충돌하거나 3초가 지나면 총알 제거

## Inspector에서 바꿔 보기

- 씬의 Player → Player Controller → Move Speed: 플레이어 속도
- 프리팹의 Bullet → Bullet → Speed / Life Time: 총알 속도 / 유지 시간
- Player 아래 FirePoint → Local Position: 총알이 나오는 위치. 플레이어 콜라이더 바깥에 둡니다.

총알 프리팹은 `Prefabs/Bullet.prefab`입니다. Sphere Collider, Rigidbody, Bullet 스크립트가 붙어 있습니다.
총알은 중력 없이 직진하고 실제 Collider 충돌을 사용합니다. 플레이어는 Transform으로만 움직이므로 벽이나 상자를 막아 주는 이동 충돌 처리는 없습니다.

직접 연결해 보려면 Player의 Bullet Prefab 칸에 Bullet 프리팹을, Fire Point 칸에 자식 FirePoint를 드래그하세요. 제공된 씬에는 이미 연결되어 있습니다.

